using System;
using System.Data.Odbc;
using System.Linq;
using AddressesClassifier;

namespace ConsoleUsing
{
    public static class Program
    {
        //private const string Folder = @"E:\projects\strill\adresses\base";
        private const string Folder = @"C:\db\Base";

        private static void Main()
        {
            try
            {
                ReadOdbc();
                ReadOleDbModel();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadLine();
        }

        private static void ReadNdbfDt()
        {
            var date = DateTime.Now;
            var reader = new ReadKladr(Folder);
            var db = reader.NdbfReader().ReadRegion("01");
            for (var i = 0; i < db.Rows.Count; i++)
                Console.WriteLine("{0} {1} {2} {3}", db.Rows[i]["code"], db.Rows[i]["name"], db.Rows[i]["trimcode"],
                    db.Rows[i]["socr"]);
            Console.WriteLine(DateTime.Now - date);
        }

        private static void ReadOleDbModel()
        {
            var date = DateTime.Now;
            var reader = new ReadKladr(Folder);
            var db = reader.OleDbReader().ReadBaseInfoModel();
            foreach (var item in db)
                Console.WriteLine("{0} {1} {2} {3}", item.Code, item.Contraction, item.Name, item.TrimCode);
            Console.WriteLine(DateTime.Now - date);
        }

        private static void ReadNdbfModel()
        {
            var reader = new ReadKladr(Folder);
            var db = reader.NdbfReader().ReadBaseInfoModel();

            Console.WriteLine("Count " + db.Count());
            var item = db.FirstOrDefault();
            Console.WriteLine("{0} {1} {2} {3}", item.Code, item.Contraction, item.Name, item.TrimCode);
        }

        private static void ReadOdbc()
        {
            var date = DateTime.Now;
            var connection = new OdbcConnection
            {
                ConnectionString = @"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" + Folder + ""
            };
            connection.Open();
            var reader = connection.CreateCommand();
            reader.CommandText =
                "SELECT [name], [code], [socr], LEFT([code],2) as TrimCode FROM kladr where [code] LIKE '%00000000000'";
            using (var dataReader = reader.ExecuteReader())
                while (dataReader.Read())
                    Console.WriteLine("{0} {1} {2} {3}", dataReader["code"], dataReader["name"], dataReader["socr"],
                        dataReader["TrimCode"]);
            var t = DateTime.Now - date;
            Console.WriteLine(t);
        }
    }
}