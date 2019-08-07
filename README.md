# 3dcartSampleCustomShippingServiceApp

3dcartSampleCustomShippingServiceApp


This app is a sample application created by 3dCart simulating an independent shipping service app getting real-time shipping rates to be used on the 3dcart stores where this service is used.

The app is built in .NET MCV (C#) and it is structured as follows:

3dcartSampleCustomShippingServiceApp

Controllers

-- RatesController: Manages the get rates process between the cart and the custom shipping app

Models

-- Classes representing the data exchanged with the cart

(RatesRequest, RatesResponse, Shippingfrom, Shippingmethod, Shippingto, Item)

Services

-- Business logic implementation -- Methods helping exchanging data between the controllers and the external endpoints

(RatesService, HttpContextService)
