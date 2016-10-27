using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Web;

namespace WcfFormatAutoSelect
{
   
    public class CustomErrorHandler : IErrorHandler
    {

        public bool HandleError(Exception error)
        {
            if (WebOperationContext.Current?.IncomingRequest.Accept != "application/json")
                return false;
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (WebOperationContext.Current?.IncomingRequest.Accept != "application/json")
                return;

            // Create message
            var jsonError = new JsonErrorDetails
            {
                Message = error.Message,
                ExceptionType = error.GetType().FullName
            };

            fault = Message.CreateMessage(version, "", jsonError,
                                          new DataContractJsonSerializer(typeof(JsonErrorDetails)));

            // Tell WCF to use JSON encoding rather than default XML
            var wbf = new WebBodyFormatMessageProperty(WebContentFormat.Json);
            fault.Properties.Add(WebBodyFormatMessageProperty.Name, wbf);

            // Modify response
            var rmp = new HttpResponseMessageProperty
            {
                StatusCode = HttpStatusCode.BadRequest,
                StatusDescription = "Bad Request",
            };

            rmp.Headers[HttpResponseHeader.ContentType] = "application/json";
            fault.Properties.Add(HttpResponseMessageProperty.Name, rmp);
        }
    }
}