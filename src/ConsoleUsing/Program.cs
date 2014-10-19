using System;
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
            var reader = new ReaderKladr(Folder);
            var db = reader.NdbfReader().ReadRegion("01");
            for (var i = 0; i < db.Rows.Count; i++)
                Console.WriteLine("{0} {1} {2} {3}", db.Rows[i]["code"], db.Rows[i]["name"], db.Rows[i]["trimcode"],
                    db.Rows[i]["socr"]);
            Console.WriteLine(DateTime.Now - date);
        }

        private static void ReadOleDbModel()
        {
            var date = DateTime.Now;
            var reader = new ReaderKladr(Folder);
            var db = reader.OleDbReader().ReadBaseInfoModel();
            foreach (var item in db)
                Console.WriteLine("{0} {1} {2} {3}", item.Code, item.Contraction, item.Name, item.TrimCode);
            Console.WriteLine(DateTime.Now - date);
        }

        private static void ReadNdbfModel()
        {
            var reader = new ReaderKladr(Folder);
            var db = reader.NdbfReader().ReadBaseInfoModel();

            Console.WriteLine("Count " + db.Count());
            var item = db.FirstOrDefault();
            Console.WriteLine("{0} {1} {2} {3}", item.Code, item.Contraction, item.Name, item.TrimCode);
        }
    }
}