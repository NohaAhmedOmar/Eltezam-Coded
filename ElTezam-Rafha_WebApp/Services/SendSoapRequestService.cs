using Eltezam_Coded.DTOs;
using ElTezam_Coded_WebApp.DTOs;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.SqlTypes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace ElTezam_Coded_WebApp.Services
{
    public interface ISendSoapRequestService
    {
        Task<ResponseModel> SendRequest(string EndPoint,string Body, string SoapAction);
    }
    public class SendSoapRequestService: ISendSoapRequestService
    {
        private readonly HttpClient httpClient;
        public SendSoapRequestService(IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
        }

        public async Task<ResponseModel> SendRequest(string EndPoint, string Body,string SoapAction)
        {
            try
            {
                string xml = @$"<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
	<s:Body xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
		<SubmitEmployeeInfoResponse xmlns=""http://tempuri.org/"">
			<SubmitEmployeeInfoResult>
				<submitEmployeeInfoResponseDetailObject xmlns="""">
					<RequestNumber xmlns=""http://yefi.gov.sa/MCS/EltezamDataSchema/xml/schemas/version2.0"">20230815107901282</RequestNumber>
				</submitEmployeeInfoResponseDetailObject>
			</SubmitEmployeeInfoResult>
		</SubmitEmployeeInfoResponse>
	</s:Body>
</s:Envelope>";

                XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xml));
                string RequestNumber = xmlDocumentWithoutNs.Value;
                //var xmlWithoutNs = xmlDocumentWithoutNs.ToString();

                // SOAP request payload
                string soapRequest = Body;
                //  httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/soap+xml"));
                // Set the SOAP endpoint URL
                string url = EndPoint;

                // Set the appropriate headers for a SOAP request
                var content = new StringContent(soapRequest, Encoding.UTF8, "text/xml");
                httpClient.DefaultRequestHeaders.Add("SOAPAction", SoapAction);
                // Send the SOAP request
                HttpResponseMessage response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read the SOAP response content
                    string soapResponse = await response.Content.ReadAsStringAsync();

                    XElement SOAPxmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(soapResponse));
                    string SOAPRequestNumber = xmlDocumentWithoutNs.Value;
                    //var xmlWithoutNs = xmlDocumentWithoutNs.ToString();

                    //var doc = XDocument.Parse(soapResponse);
                    //var respo = JsonConvert.SerializeXNode(doc);

                    //var doc2 = new XmlDocument();
                    //doc2.LoadXml(soapResponse);
                    //var respo2 = JsonConvert.SerializeXmlNode(doc2);

                    //var doc3 = XDocument.Parse(soapResponse);
                    //var respo3 = JsonConvert.SerializeXNode(doc3, Newtonsoft.Json.Formatting.Indented);

                    //var doc4 = XDocument.Parse(soapResponse);
                    //var respo4 = JsonConvert.SerializeXNode(doc, Newtonsoft.Json.Formatting.None, omitRootObject: true);

                    // Process the SOAP response as needed
                    // ...

                    return new ResponseModel { Data = response.ReasonPhrase, StatusCode = (int)response.StatusCode, IsSuccess = response.IsSuccessStatusCode, SOAPRequestNumber = SOAPRequestNumber };
                }
                else
                {
                    return new ResponseModel { Data = response.ReasonPhrase, StatusCode = (int)response.StatusCode, IsSuccess = response.IsSuccessStatusCode };
                }
            }
            catch (Exception ex)
            {
                return new ResponseModel { Data = ex.Message, StatusCode = 500, IsSuccess = false };
            }
        }

        public static string RemoveAllNamespaces(string xmlDocument)
        {

            XElement xmlDocumentWithoutNs = RemoveAllNamespaces(XElement.Parse(xmlDocument));

            return xmlDocumentWithoutNs.ToString();
        }

        //Core recursion function
        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }
    }
}
