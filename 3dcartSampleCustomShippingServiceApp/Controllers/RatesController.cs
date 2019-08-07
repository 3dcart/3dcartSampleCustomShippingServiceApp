using _3dcartSampleCustomShippingServiceApp.Interfaces;
using _3dcartSampleCustomShippingServiceApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace _3dcartSampleCustomShippingServiceApp.Controllers
{
    public class RatesController : Controller
    {
        private IRatesService _ratesService;

        public RatesController(IRatesService ratesService)
        {
            _ratesService = ratesService;
        }

        // GET: Rates
        public ActionResult GetRates(RatesRequest jsonRatesRequest)
        {
            RatesResponse jsonRatesResponse = null;
            bool isValid = false;         

            //Validate credentials
            try
            {
                isValid = _ratesService.ValidateCredentials();
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, ex.Message);
            }
                         
            if (!isValid)
                return new HttpStatusCodeResult(HttpStatusCode.Unauthorized, "Invalid Credentials");
            
            //Validate request   
            try
            {
                isValid = _ratesService.ValidateRequest(jsonRatesRequest);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }

            if (!isValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
                        
            //Proceed to calculates the rates
            try
            {
                jsonRatesResponse = _ratesService.GetShippingRates(jsonRatesRequest);
            }
            catch { }

            if (jsonRatesResponse == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            return Json(jsonRatesResponse);
        }
    }
}