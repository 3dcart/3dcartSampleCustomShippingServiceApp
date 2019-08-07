using _3dcartSampleCustomShippingServiceApp.Interfaces;
using _3dcartSampleCustomShippingServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace _3dcartSampleCustomShippingServiceApp.Services
{
    public class RatesService : IRatesService
    {
        const string expectedUser = "User1";
        const string expectedPass = "Pass1";

        private IHttpContextService _httpContextService;

        public RatesService(IHttpContextService httpContextService)
        {
            _httpContextService = httpContextService;
        }             

        public bool ValidateCredentials()
        {
            var request = _httpContextService.Request;
                   
            var authHeader = request.Headers.Get("Authorization");
            
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Basic "))
                throw new Exception("The authorization header is either empty or isn't Basic.");

            var credentials = authHeader.Substring("Basic ".Length);

            credentials = DecodeFrom64(credentials);

            int separator = credentials.IndexOf(':');
            string username = credentials.Substring(0, separator);
            string password = credentials.Substring(separator + 1);

            return CheckPassword(username, password);
        }

        private bool CheckPassword(string username, string password)
        {
            return (username == expectedUser && password == expectedPass);
        }

        static public string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = Convert.FromBase64String(encodedData);
            string returnValue = Encoding.ASCII.GetString(encodedDataAsBytes);
            return returnValue;
        }

        public RatesResponse GetShippingRates(RatesRequest request)
        {
            RatesResponse response = null;


            //Calculate rates based on the request shippingfrom and shippingto information
            //Do something here....

            //Hardcoding shipping rates for this sample app
            List <Shippingmethod> shippingmethods = new List<Shippingmethod>();
            shippingmethods.Add(new Shippingmethod() { methodname = "DHL Priority", rate = 32.00 });
            shippingmethods.Add(new Shippingmethod() { methodname = "USPS First Class", rate = 3.00 });
            shippingmethods.Add(new Shippingmethod() { methodname = "UPS Ground", rate = 12.00 });

            response = new RatesResponse() { shippingmethods = shippingmethods };

            return response;
        }

        public bool ValidateRequest(RatesRequest jsonRatesRequest)
        {
            bool isValid = true;

            var request = _httpContextService.Request;                       
                   
            if (string.IsNullOrEmpty(request.ContentType) || request.ContentType != "application/json; charset= utf-8")
                throw new Exception("The content type is either empty or isn't application/json.");

            if (string.IsNullOrEmpty(request.HttpMethod) || request.HttpMethod != "POST")
                throw new Exception("The HttpMethod is either empty or isn't POST.");

            //Validate JSON request checking all the required information is valid

            if (jsonRatesRequest.shippingfrom == null)
                isValid = false;
            else           
                if (string.IsNullOrEmpty(jsonRatesRequest.shippingfrom.country) || string.IsNullOrEmpty(jsonRatesRequest.shippingfrom.state))
                    isValid = false;
                    
            if (jsonRatesRequest.shippingto == null)
                isValid = false;
            else            
                if (string.IsNullOrEmpty(jsonRatesRequest.shippingto.postalcode) || string.IsNullOrEmpty(jsonRatesRequest.shippingto.country) || string.IsNullOrEmpty(jsonRatesRequest.shippingto.state))
                    isValid = false;
            
            //Do anay other validation here

            return isValid;
        }
    }
}