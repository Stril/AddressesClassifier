using System;
using System.Linq;
using AddressesClassifier;

namespace ConsoleUsing
{
    public static class Program
    {
        private const string Folder = @"E:\Projects\Strill\Addresses\base";

        private static void Main()
        {
            try
            {
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
            var reader = new ReadKladr(Folder);
            var db = reader.NdbfReader().ReadRegion("01");
            Console.WriteLine(db.Rows.Count);

            for (var i = 0; i < db.Rows.Count; i++)
                Console.WriteLine("{0} {1} {2} {3}", db.Rows[i]["code"], db.Rows[i]["name"], db.Rows[i]["trimcode"],
                    db.Rows[i]["socr"]);
        }

        private static void ReadOleDbModel()
        {
            var reader = new ReadKladr(Folder);

            var db = reader.OleDbReader().ReadBaseInfoModel();

            Console.WriteLine("Count " + db.Count());

            foreach (var item in db)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Code, item.Contraction, item.Name, item.TrimCode);
            }
        }

        private static void ReadNdbfModel()
        {
            var reader = new ReadKladr(Folder);
            var db = reader.NdbfReader().ReadBaseInfoModel();

            Console.WriteLine("Count " + db.Count());
            var item = db.FirstOrDefault();
            Console.WriteLine("{0} {1} {2} {3}", item.Code, item.Contraction, item.Name, item.TrimCode);
        }
    }
}

