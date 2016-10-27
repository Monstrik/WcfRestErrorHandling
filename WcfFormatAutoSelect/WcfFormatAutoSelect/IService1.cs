using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfFormatAutoSelect
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        //[WebInvoke(
        //    Method = "GET", 
        //    //ResponseFormat = WebMessageFormat.Json,
        //    UriTemplate = "/GetData")]
        CompositeType GetData();


        [OperationContract]
        
        string GetDataWithParam(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
       
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    [DataContract]
    public class ServiceErrorDetail
    {
        public ServiceErrorDetail(Exception ex)
        {
            Error = ex.Message;
            Detail = ex.Source;
        }
        [DataMember]
        public String Error { get; set; }
        [DataMember]
        public String Detail { get; set; }
    }

}
