using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private const string ConnectionString =
            "Server=tcp:eksamensserver.database.windows.net,1433;Initial Catalog=EksamensDB;Persist Security Info=False;User ID=moha2896;Password=Pass1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        // public static List<Catch> CatchList;

        private static Catch ReadCatch(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string navn = reader.GetString(1);
            int uge = reader.GetInt32(3);
            string art = reader.GetString(2);
            Catch catchi = new Catch()
            {
                id = id,
                navn = navn,
                uge = uge,
                art = art
            };
            return catchi;
        }
        public Service1()
        {
            // CatchList = new List<Catch>();
        }

        public int AddCatch(string navn, string art, int uge)
        {
            const string insertCatch = "insert into Catch (navn, art, uge) values (@navn, @art, @uge)";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(insertCatch, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@navn", navn);
                    insertCommand.Parameters.AddWithValue("@art", art);
                    insertCommand.Parameters.AddWithValue("@uge", uge);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
        /*  public string DeleteCatc(int id)
          {
                  foreach (Catch a in CatchList)
                  {
                      if (a.id == id)
                      {
                          CatchList.Remove(a);
                      }

                  }

                  return $"A fish has been removed from the list";



          }
            */

        public Catch GetCatchById(int id)
        {
            /*  Catch Fisk = new Catch(1,"m","m",1);
              foreach(Catch a in CatchList)
              {
                  if (a.id == id)
                  {
                      Fisk = a;
                      break;
                  }

              }

              return Fisk;*/

            const string selectCatch = "select * from student where id=@id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectCatch, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return null;
                        }
                        reader.Read(); // Advance cursor to first row
                        Catch catchi = ReadCatch(reader);
                        return catchi;
                    }
                }
            }
        }

        public List<Catch> GetCatches()
        {
            const string selectAllCatches = "select * from Catch order by navn";

            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectAllCatches, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Catch> catchList = new List<Catch>();
                        while (reader.Read())
                        {
                            Catch @catch = ReadCatch(reader);

                            catchList.Add(@catch);
                        }
                        return catchList;
                    }
                }
            }
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
