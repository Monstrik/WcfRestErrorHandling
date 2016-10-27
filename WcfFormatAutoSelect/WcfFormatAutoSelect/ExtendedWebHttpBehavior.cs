using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Web;

namespace WcfFormatAutoSelect
{

    /// <summary>
    /// This class is a custom implementation of the WebHttpBehavior. 
    /// The main of this class is to handle exception and to serialize those as requests that will be understood by the web application.
    /// </summary>
    public class ExtendedWebHttpBehavior : WebHttpBehavior
    {
        protected override void AddServerErrorHandlers(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Clear();
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new CustomErrorHandler());
        }
    }

}