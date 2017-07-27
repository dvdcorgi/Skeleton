using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SkelService.Model;

namespace SkelService
{

    public class Service1 : IServiceSkeleton
    {
        dbSkeletonEntities db = new dbSkeletonEntities();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public bool AddItem(tblSkeleton tSkeleton)
        {
            try
            {
                tblSkeleton t = new tblSkeleton();
                t.Name = tSkeleton.Name;
                t.Code = tSkeleton.Code;
                db.tblSkeletons.Add(t);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddItem error: " + ex.Message);
                return false;
            }
        }

        public List<tblSkeleton> GetItems(string itemName)
        {
            List<tblSkeleton> listSkeleton = (from a in db.tblSkeletons
                                        where a.Name.Contains(itemName)
                                        select a).ToList();
            return listSkeleton;
        }

        public bool UpdateItem(tblSkeleton tSkeleton)
        {
            try
            {
                tblSkeleton t = (from a in db.tblSkeletons
                                 where a.id == tSkeleton.id
                                 select a).FirstOrDefault();
                t.Name = tSkeleton.Name;
                t.Code = tSkeleton.Code;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateItem error: " + ex.Message);
                return false;
            }
        }
    }
}
