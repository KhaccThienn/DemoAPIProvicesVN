using Oracle.ManagedDataAccess.Types;

namespace DemoAPIProvicesVN.Extensions
{
    public static class OracleParameterCollectionExtensions
    {
        public static OracleParameter AddUdt(this OracleParameterCollection collection, string parameterName, string udtTypeName, IOracleCustomType customType)
        {
            var parameter = new OracleParameter(parameterName, OracleDbType.Array)
            {
                UdtTypeName = udtTypeName,
                Value = customType,
                Direction = ParameterDirection.Input
            };

            return collection.Add(parameter);
        }

        public static ResponseModel GetResponseModel(this OracleParameterCollection parameters, string paraMessName, string paraCodeName)
        {
            // Nếu parameters không có paraMessName và paraCodeName thì throw exception
            if (!parameters.Contains(paraMessName) || !parameters.Contains(paraCodeName))
                throw new InvalidDataException(paraMessName + " or " + paraCodeName + " not found in parameters.");

            string returnMess = parameters[paraMessName].Value.ToString();
            string returnCode = parameters[paraCodeName].Value.ToString();
            var code = long.Parse(returnCode);

            return new ResponseModel { Code = code, Message = returnMess };
        }

        public static void SetOutputParameter(
        this OracleParameterCollection parameters,
        string paraCodeName = null,
        string paraMessName = null,
        string paraRsName = null)
        {
            if (!String.IsNullOrWhiteSpace(paraRsName))
                parameters.Add(paraRsName, OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            if (!String.IsNullOrWhiteSpace(paraCodeName))
                parameters.Add(paraCodeName, OracleDbType.Int32).Direction = ParameterDirection.Output;
            if (!String.IsNullOrWhiteSpace(paraMessName))
                parameters.Add(paraMessName, OracleDbType.Varchar2, size: 2000).Direction = ParameterDirection.Output;
        }
    }
}
