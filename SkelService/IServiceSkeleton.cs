using SkelService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SkelService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceSkeleton
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        bool AddItem(tblSkeleton tSkeleton);

        [OperationContract]
        List<tblSkeleton> GetItems(string itemName);

        [OperationContract]
        bool UpdateItem(tblSkeleton tSkeleton);

    }

    
}
