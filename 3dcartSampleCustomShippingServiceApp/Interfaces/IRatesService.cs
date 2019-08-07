using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3dcartSampleCustomShippingServiceApp.Models;

namespace _3dcartSampleCustomShippingServiceApp.Interfaces
{
    public interface IRatesService
    {
        bool ValidateCredentials();       
        bool ValidateRequest(RatesRequest jsonRatesRequest);
        RatesResponse GetShippingRates(RatesRequest request);
    }
}
