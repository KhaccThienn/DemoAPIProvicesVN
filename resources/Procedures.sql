-- Proc GetAllAdministrative_Regions
CREATE OR REPLACE PROCEDURE GetAllAdministrative_Regions(
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT
            "A1"."ID"           "ID",
            "A1"."NAME"         "NAME",
            "A1"."NAME_EN"      "NAME_EN",
            "A1"."CODE_NAME"    "CODE_NAME",
            "A1"."CODE_NAME_EN" "CODE_NAME_EN"
        FROM
            "DB_VN_PROVINCES"."ADMINISTRATIVE_REGIONS" "A1"
        ORDER BY ID ASC;
END GetAllAdministrative_Regions;

-- Proc GetAllAdministrative_Units
CREATE OR REPLACE PROCEDURE GetAllAdministrative_Units(
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT
            "A1"."ID"            "ID",
            "A1"."FULL_NAME"     "FULL_NAME",
            "A1"."FULL_NAME_EN"  "FULL_NAME_EN",
            "A1"."SHORT_NAME"    "SHORT_NAME",
            "A1"."SHORT_NAME_EN" "SHORT_NAME_EN",
            "A1"."CODE_NAME"     "CODE_NAME",
            "A1"."CODE_NAME_EN"  "CODE_NAME_EN"
        FROM
            "DB_VN_PROVINCES"."ADMINISTRATIVE_UNITS" "A1"
        ORDER BY ID ASC;
END GetAllAdministrative_Units;

-- Proc GetAllDistricts
CREATE OR REPLACE PROCEDURE GetAllDistricts(
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT
            "A1"."CODE"                   "CODE",
            "A1"."NAME"                   "NAME",
            "A1"."NAME_EN"                "NAME_EN",
            "A1"."FULL_NAME"              "FULL_NAME",
            "A1"."FULL_NAME_EN"           "FULL_NAME_EN",
            "A1"."CODE_NAME"              "CODE_NAME",
            "A1"."PROVINCE_CODE"          "PROVINCE_CODE",
            "A1"."ADMINISTRATIVE_UNIT_ID" "ADMINISTRATIVE_UNIT_ID",
            p.full_name as "Province_Name",
            p.full_name_en as "Province_Name_En",
            au.full_name as "Unit_Name",
            au.full_name_en as "Unit_Name_En"
        FROM
            "DISTRICTS" "A1" 
            JOIN Provinces p ON A1.PROVINCE_CODE = p.code
            JOIN ADMINISTRATIVE_UNITS au ON  "A1"."ADMINISTRATIVE_UNIT_ID" = au.id
        ORDER BY "A1"."CODE" ASC;
END GetAllDistricts;

-- Proc GetAllProvinces
CREATE OR REPLACE PROCEDURE GetAllProvinces(
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT 
            p.CODE ,
            p.NAME ,
            p.NAME_EN ,
            p.FULL_NAME ,
            p.FULL_NAME_EN ,
            p.CODE_NAME ,
            p.ADMINISTRATIVE_UNIT_ID,
            p.ADMINISTRATIVE_REGION_ID,
            ar.name AS region_Name,
            ar.name_en AS region_Name_En,
            au.full_name AS unit_Name,
            au.full_name_en AS unit_Name_en
            FROM provinces p 
            JOIN administrative_units au ON p.ADMINISTRATIVE_UNIT_ID = au.id
            JOIN administrative_regions ar ON p.ADMINISTRATIVE_REGION_ID = ar.id
            ORDER BY p.CODE ASC;
END GetAllProvinces;

CREATE OR REPLACE PROCEDURE GetAllProvincesByAdminisTrativeUnitCode(
    p_id IN NUMBER,
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT 
            p.CODE ,
            p.NAME ,
            p.NAME_EN ,
            p.FULL_NAME ,
            p.FULL_NAME_EN ,
            p.CODE_NAME ,
            p.ADMINISTRATIVE_UNIT_ID,
            p.ADMINISTRATIVE_REGION_ID,
            ar.name AS region_Name,
            ar.name_en AS region_Name_En,
            au.full_name AS unit_Name,
            au.full_name_en AS unit_Name_en
            FROM provinces p 
            JOIN administrative_units au ON p.ADMINISTRATIVE_UNIT_ID = au.id
            JOIN administrative_regions ar ON p.ADMINISTRATIVE_REGION_ID = ar.id
            WHERE au.id = p_id
            ORDER BY p.CODE ASC;
END GetAllProvincesByAdminisTrativeUnitCode;

CREATE OR REPLACE PROCEDURE GetAllProvincesByAdminisTrativeRegionCode(
    p_id IN NUMBER,
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT 
            p.CODE ,
            p.NAME ,
            p.NAME_EN ,
            p.FULL_NAME ,
            p.FULL_NAME_EN ,
            p.CODE_NAME ,
            p.ADMINISTRATIVE_UNIT_ID,
            p.ADMINISTRATIVE_REGION_ID,
            ar.name AS region_Name,
            ar.name_en AS region_Name_En,
            au.full_name AS unit_Name,
            au.full_name_en AS unit_Name_en
            FROM provinces p 
            JOIN administrative_units au ON p.ADMINISTRATIVE_UNIT_ID = au.id
            JOIN administrative_regions ar ON p.ADMINISTRATIVE_REGION_ID = ar.id
            WHERE ar.id = p_id
            ORDER BY p.CODE ASC;
END GetAllProvincesByAdminisTrativeRegionCode;

-- Proc GetAllWards
CREATE OR REPLACE PROCEDURE GetAllWards(
    p_page_number IN NUMBER,
    p_page_size IN NUMBER,
    p_result OUT SYS_REFCURSOR
) AS
    v_offset NUMBER;
BEGIN
    -- Calculate the offset based on the page number and page size
    v_offset := (p_page_number - 1) * p_page_size;

    OPEN p_result FOR
        SELECT * FROM (
            SELECT 
                w.CODE,
                w.NAME,
                w.NAME_EN,
                w.FULL_NAME,
                w.FULL_NAME_EN,
                w.CODE_NAME,
                w.DISTRICT_CODE,
                w.ADMINISTRATIVE_UNIT_ID,
                au.FULL_NAME as UNIT_NAME,
                au.FULL_NAME_EN as UNIT_NAME_EN,
                d.FULL_NAME as DISTRICT_NAME,
                d.FULL_NAME_EN as DISTRICT_NAME_EN,                
                ROW_NUMBER() OVER (ORDER BY w.CODE) AS rnum
            FROM wards w
            LEFT JOIN administrative_units au ON w.administrative_unit_id = au.id
            JOIN districts d ON d.code = w.DISTRICT_CODE
        )
        WHERE rnum > v_offset AND rnum <= v_offset + p_page_size;
END GetAllWards;

-- Proc GetProvinceByCode
CREATE OR REPLACE PROCEDURE GetProvinceByCode(
    p_code IN VARCHAR2,
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT 
            p.CODE ,
            p.NAME ,
            p.NAME_EN ,
            p.FULL_NAME ,
            p.FULL_NAME_EN ,
            p.CODE_NAME ,
            p.ADMINISTRATIVE_UNIT_ID,
            p.ADMINISTRATIVE_REGION_ID,
            ar.name AS region_Name,
            ar.name_en AS region_Name_En,
            au.full_name AS unit_Name,
            au.full_name_en AS unit_Name_en
        FROM provinces p
        LEFT JOIN administrative_regions ar ON p.administrative_region_id = ar.id
        LEFT JOIN administrative_units au ON p.administrative_unit_id = au.id
        WHERE p.code = p_code;
END GetProvinceByCode;

-- Proc GetDistrictsByProvinceCode
CREATE OR REPLACE PROCEDURE GetDistrictsByProvinceCode(
    p_province_code IN VARCHAR2,
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT
            "A1"."CODE"                   "CODE",
            "A1"."NAME"                   "NAME",
            "A1"."NAME_EN"                "NAME_EN",
            "A1"."FULL_NAME"              "FULL_NAME",
            "A1"."FULL_NAME_EN"           "FULL_NAME_EN",
            "A1"."CODE_NAME"              "CODE_NAME",
            "A1"."PROVINCE_CODE"          "PROVINCE_CODE",
            "A1"."ADMINISTRATIVE_UNIT_ID" "ADMINISTRATIVE_UNIT_ID",
            p.full_name as "Province_Name",
            p.full_name_en as "Province_Name_En",
            au.full_name as "Unit_Name",
            au.full_name_en as "Unit_Name_En"
        FROM
            "DISTRICTS" "A1" 
            JOIN Provinces p ON A1.PROVINCE_CODE = p.code
            JOIN ADMINISTRATIVE_UNITS au ON  "A1"."ADMINISTRATIVE_UNIT_ID" = au.id
        WHERE p.Code = p_province_code
        ORDER BY "A1"."CODE" ASC;
END GetDistrictsByProvinceCode;

-- Proc GetDistrictByCode
CREATE OR REPLACE PROCEDURE GetDistrictByCode(
    p_code IN VARCHAR2,
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT
            "A1"."CODE"                   "CODE",
            "A1"."NAME"                   "NAME",
            "A1"."NAME_EN"                "NAME_EN",
            "A1"."FULL_NAME"              "FULL_NAME",
            "A1"."FULL_NAME_EN"           "FULL_NAME_EN",
            "A1"."CODE_NAME"              "CODE_NAME",
            "A1"."PROVINCE_CODE"          "PROVINCE_CODE",
            "A1"."ADMINISTRATIVE_UNIT_ID" "ADMINISTRATIVE_UNIT_ID",
            p.full_name as "Province_Name",
            p.full_name_en as "Province_Name_En",
            au.full_name as "Unit_Name",
            au.full_name_en as "Unit_Name_En"
        FROM
            "DISTRICTS" "A1" 
            JOIN Provinces p ON A1.PROVINCE_CODE = p.code
            JOIN ADMINISTRATIVE_UNITS au ON  "A1"."ADMINISTRATIVE_UNIT_ID" = au.id
            WHERE A1.code = p_code;
END GetDistrictByCode;

CREATE OR REPLACE PROCEDURE GetWardsByDistrictCode(
    p_district_code IN VARCHAR2,
    p_page_number IN NUMBER,
    p_page_size IN NUMBER,
    p_result OUT SYS_REFCURSOR
) AS
    v_offset NUMBER;
BEGIN
    -- Calculate the offset based on the page number and page size
    v_offset := (p_page_number - 1) * p_page_size;

    OPEN p_result FOR
        SELECT * FROM (
            SELECT 
                w.CODE,
                w.NAME,
                w.NAME_EN,
                w.FULL_NAME,
                w.FULL_NAME_EN,
                w.CODE_NAME,
                w.DISTRICT_CODE,
                w.ADMINISTRATIVE_UNIT_ID,
                au.FULL_NAME AS UNIT_NAME,
                au.FULL_NAME_EN AS UNIT_NAME_EN,
                d.FULL_NAME AS DISTRICT_NAME,
                d.FULL_NAME_EN AS DISTRICT_NAME_EN,
                ROW_NUMBER() OVER (ORDER BY w.CODE) AS rnum
            FROM wards w
            LEFT JOIN administrative_units au ON w.administrative_unit_id = au.id
            JOIN districts d ON d.code = w.DISTRICT_CODE
            WHERE w.DISTRICT_CODE = p_district_code
        )
        WHERE rnum > v_offset AND rnum <= v_offset + p_page_size;
END GetWardsByDistrictCode;

-- Proc GetWardByCode
CREATE OR REPLACE PROCEDURE GetWardByCode(
    p_code IN VARCHAR2,
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT 
            w.CODE,
            w.NAME,
            w.NAME_EN,
            w.FULL_NAME,
            w.FULL_NAME_EN,
            w.CODE_NAME,
            w.DISTRICT_CODE,
            w.ADMINISTRATIVE_UNIT_ID,
            au.FULL_NAME as UNIT_NAME,
            au.FULL_NAME_EN as UNIT_NAME_EN,
            d.FULL_NAME as DISTRICT_NAME,
            d.FULL_NAME_EN as DISTRICT_NAME_EN,                
            ROW_NUMBER() OVER (ORDER BY w.CODE) AS rnum
        FROM wards w
        LEFT JOIN administrative_units au ON w.administrative_unit_id = au.id
        JOIN districts d ON d.code = w.DISTRICT_CODE
        WHERE w.code = p_code;
END GetWardByCode;

-- Proc SearchProvinces
CREATE OR REPLACE PROCEDURE SearchProvinces(
    p_search_term IN VARCHAR2,
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT 
            p.CODE ,
            p.NAME ,
            p.NAME_EN ,
            p.FULL_NAME ,
            p.FULL_NAME_EN ,
            p.CODE_NAME ,
            p.ADMINISTRATIVE_UNIT_ID,
            p.ADMINISTRATIVE_REGION_ID,
            ar.name AS region_Name,
            ar.name_en AS region_Name_En,
            au.full_name AS unit_Name,
            au.full_name_en AS unit_Name_en
        FROM provinces p
        LEFT JOIN administrative_regions ar ON p.administrative_region_id = ar.id
        LEFT JOIN administrative_units au ON p.administrative_unit_id = au.id
        WHERE LOWER(p.NAME) LIKE '%' || LOWER(p_search_term) || '%'
           OR LOWER(p.NAME_EN) LIKE '%' || LOWER(p_search_term) || '%'
           OR LOWER(p.FULL_NAME) LIKE '%' || LOWER(p_search_term) || '%'
        ORDER BY p.NAME;
END SearchProvinces;

-- Proc SearchDistricts
CREATE OR REPLACE PROCEDURE SearchDistricts(
    p_search_term IN VARCHAR2,
    p_result OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_result FOR
        SELECT 
            d.CODE,
            d.NAME,
            d.NAME_EN,
            d.FULL_NAME,
            d.FULL_NAME_EN,
            d.CODE_NAME,
            d.PROVINCE_CODE,
            d.ADMINISTRATIVE_UNIT_ID,
            p.full_name as "Province_Name",
            p.full_name_en as "Province_Name_En",
            au.full_name as "Unit_Name",
            au.full_name_en as "Unit_Name_En"
        FROM districts d
        LEFT JOIN provinces p ON d.province_code = p.code
        LEFT JOIN administrative_units au ON d.administrative_unit_id = au.id
        WHERE LOWER(d.NAME) LIKE '%' || LOWER(p_search_term) || '%'
           OR LOWER(d.NAME_EN) LIKE '%' || LOWER(p_search_term) || '%'
           OR LOWER(d.FULL_NAME) LIKE '%' || LOWER(p_search_term) || '%'
        ORDER BY d.NAME;
END SearchDistricts;

-- Proc SearchWards
CREATE OR REPLACE PROCEDURE SearchWards(
    p_search_term IN VARCHAR2,
    p_page_number IN NUMBER,
    p_page_size IN NUMBER,
    p_result OUT SYS_REFCURSOR
) AS
    v_offset NUMBER;
BEGIN
    -- Calculate the offset for pagination
    v_offset := (p_page_number - 1) * p_page_size;

    OPEN p_result FOR
        SELECT * FROM (
            SELECT 
                w.CODE,
                w.NAME,
                w.NAME_EN,
                w.FULL_NAME,
                w.FULL_NAME_EN,
                w.CODE_NAME,
                w.DISTRICT_CODE,
                w.ADMINISTRATIVE_UNIT_ID,
                au.FULL_NAME as UNIT_NAME,
                au.FULL_NAME_EN as UNIT_NAME_EN,
                d.FULL_NAME as DISTRICT_NAME,
                d.FULL_NAME_EN as DISTRICT_NAME_EN,      
                ROW_NUMBER() OVER (ORDER BY w.NAME) AS rnum
            FROM wards w
            LEFT JOIN districts d ON w.district_code = d.code
            LEFT JOIN administrative_units au ON w.administrative_unit_id = au.id
            WHERE LOWER(w.NAME) LIKE '%' || LOWER(p_search_term) || '%'
               OR LOWER(w.NAME_EN) LIKE '%' || LOWER(p_search_term) || '%'
               OR LOWER(w.FULL_NAME) LIKE '%' || LOWER(p_search_term) || '%'
        )
        WHERE rnum > v_offset AND rnum <= v_offset + p_page_size;
END SearchWards;
