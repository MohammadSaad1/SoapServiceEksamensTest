using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SoapServiceEksamensTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static List<Catch> CatchList { get; set; }
        public Service1()
        {
            CatchList = new List<Catch>();
        }   
        public string AddCatch(Catch a)
        {
            CatchList.Add(a);
            return $"{a.navn} has been added to the list";
        }

        public string DeleteCatc(int id)
        {
            foreach (Catch a in CatchList)
            {
                if(a.id == id)
                {
                    CatchList.Remove(a); 
                }

            }

            return $"A fish has been removed from the list";
        }

        
        public Catch GetCatchById(int id)
        {
            Catch Fisk = new Catch(1,"m","m",1);
            foreach(Catch a in CatchList)
            {
                if (a.id == id)
                {
                    Fisk = a;
                    break;
                }

            }

            return Fisk;
        }

        public List<Catch> GetCatches()
        {
            return CatchList;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
