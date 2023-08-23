using System.Runtime.Serialization;

namespace Eltezam_Coded.DTOs
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public object? Data { get; set; }
        public bool IsSuccess{ get; set; }=false;
        public int? RequestNumber{ get; set; }
        public string? SOAPRequestNumber { get; set; }
    }
}
