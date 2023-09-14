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
                    string SOAPRequestNumber = SOAPxmlDocumentWithoutNs.Value;

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
