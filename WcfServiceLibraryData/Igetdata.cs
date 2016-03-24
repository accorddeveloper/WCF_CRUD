using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibraryData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "Igetdata" in both code and config file together.
    [ServiceContract]
    public interface Igetdata
    {
        [OperationContract]
        List<myData> AllData();
        [OperationContract]
        void Create(myData d);
        [OperationContract]
        myData searchData(int x);

        [OperationContract]
        bool update(myData x);
    }

    [DataContract]
    public class myData
    {
        [DataMember(Order=0)]
        public int id { get; set; }
        [DataMember(Order=1)]
        public string name { get; set; }
        [DataMember(Order=2)]
        public string image { get; set; }
    }
}
