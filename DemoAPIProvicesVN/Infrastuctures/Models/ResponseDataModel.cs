namespace DemoAPIProvicesVN.Infrastuctures.Models
{
    public class ResponseDataModel<TData> : ResponseModel
    {
        [JsonIgnore]
        public bool  IsSuccessResponse { get; init; }
        public TData Data              { get; set; }
    }
}
