namespace ElTezam_Coded_WebApp.DTOs
{
    public class SOAPSXMLResponse
    {
        public SOAPSXMLBody Body { get; set; }
    }

    public class SOAPSXMLBody
    {
        public SOAPSXMLSubmitEmployeeInfoResponse SubmitEmployeeInfoResponse { get; set; }
    }

    public class SOAPSXMLSubmitEmployeeInfoResponse
    {
        public SOAPSXMLSubmitEmployeeInfoResult SubmitEmployeeInfoResult { get; set; }
    }

    public class SOAPSXMLSubmitEmployeeInfoResult
    {
        public SOAPSXMLsubmitEmployeeInfoResponseDetailObject submitEmployeeInfoResponseDetailObject { get; set; }
    }

    public class SOAPSXMLsubmitEmployeeInfoResponseDetailObject
    {
        public string RequestNumber { get; set; }
    }

}
