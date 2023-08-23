using System.Runtime.Serialization;

namespace Eltezam_Coded.DTOs
{
    [DataContract]
    public class ResponseModel
    {
        [DataMember]
        public int StatusCode { get; set; }
      /// <summary>
      ///  [DataMember]
      /// </summary>
      //  public object? Data { get; set; }
        [DataMember]
        public bool IsSuccess{ get; set; }=false;
    }
}
