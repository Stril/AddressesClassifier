using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using AddressesClassifier.Interfaces;
using AddressesClassifier.Models;
using AddressesClassifier.Services;

namespace AddressesClassifier.Implementations
{
    internal class ReadFileClassifierOleDb : IReadFileClassifier
    {
        private readonly string _folder;

        public ReadFileClassifierOleDb(string folder)
        {
            _folder = folder;
        }

        public DataTable ReadRegion(string code)
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));

            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format("SELECT [name], [code], [index], [socr] FROM kladr where [CODE] LIKE '{0}%' ", code);
            command.CommandType = CommandType.Text;

            var dataTable = new DataTable();
            dataTable.Load(command.ExecuteReader());
            return dataTable;
        }

        public DataTable ReadAllRegions()
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));

            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format("SELECT [name], [code], [index], [socr] FROM kladr");
            command.CommandType = CommandType.Text;

            var dataTable = new DataTable();
            dataTable.Load(command.ExecuteReader());
            return dataTable;
        }

        public DataTable ReadStreetsByRegion(string code)
        {
            var file = FileService.GetStreetFileNmae(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));

            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format("SELECT [name], [code], [index], [socr] FROM street where [CODE] LIKE '" + code + "%'");
            command.CommandType = CommandType.Text;

            var dataTable = new DataTable();
            dataTable.Load(command.ExecuteReader());
            return dataTable;
        }

        public DataTable ReadAllStreets()
        {
            var file = FileService.GetStreetFileNmae(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));

            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format("SELECT [name], [code], [index], [socr] FROM street");
            command.CommandType = CommandType.Text;

            var dataTable = new DataTable();
            dataTable.Load(command.ExecuteReader());
            return dataTable;
        }

        public DataTable ReadBaseInfo()
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));

            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format(
                    "SELECT [name], [code], [socr], LEFT([code],2) as TrimCode FROM kladr where [code] LIKE '%00000000000' ");
            command.CommandType = CommandType.Text;

            var dataTable = new DataTable();
            dataTable.Load(command.ExecuteReader());
            return dataTable;
        }

        public IEnumerable<Region> ReadRegionModel(string code)
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));
            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format("SELECT [name], [code], [index], [socr] FROM kladr where [CODE] LIKE '{0}%' ", code);
            command.CommandType = CommandType.Text;
            var result = new List<Region>();
            using (var dataReader = command.ExecuteReader())
                while (dataReader.Read())
                    result.Add(new Region
                    {
                        Code = dataReader["code"].ToString(),
                        Contraction = dataReader["socr"].ToString(),
                        Name = dataReader["name"].ToString(),
                        PostIndex = dataReader["index"].ToString()
                    });
            return result;
        }

        public IEnumerable<Region> ReadAllRegionsModel()
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));
            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format("SELECT [name], [code], [index], [socr] FROM kladr");
            command.CommandType = CommandType.Text;
            var result = new List<Region>();
            using (var dataReader = command.ExecuteReader())
                while (dataReader.Read())
                    result.Add(new Region
                    {
                        Code = dataReader["code"].ToString(),
                        Contraction = dataReader["socr"].ToString(),
                        Name = dataReader["name"].ToString(),
                        PostIndex = dataReader["index"].ToString()
                    });
            return result;
        }

        public IEnumerable<Street> ReadStreetsByRegionModel(string code)
        {
            var file = FileService.GetStreetFileNmae(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));

            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format("SELECT [name], [code], [index], [socr] FROM street where [CODE] LIKE '" + code + "%'");
            command.CommandType = CommandType.Text;
            var result = new List<Street>();
            using (var dataReader = command.ExecuteReader())
                while (dataReader.Read())
                    result.Add(new Street
                    {
                        Code = dataReader["code"].ToString(),
                        Contraction = dataReader["socr"].ToString(),
                        Name = dataReader["name"].ToString(),
                        PostIndex = dataReader["index"].ToString()
                    });
            return result;
        }

        public IEnumerable<Street> ReadAllStreetsModel()
        {
            var file = FileService.GetStreetFileNmae(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));

            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format("SELECT [name], [code], [index], [socr] FROM street");
            command.CommandType = CommandType.Text;
            var result = new List<Street>();
            using (var dataReader = command.ExecuteReader())
                while (dataReader.Read())
                    result.Add(new Street
                    {
                        Code = dataReader["code"].ToString(),
                        Contraction = dataReader["socr"].ToString(),
                        Name = dataReader["name"].ToString(),
                        PostIndex = dataReader["index"].ToString()
                    });
            return result;
        }

        public IEnumerable<Territory> ReadBaseInfoModel()
        {
            var file = FileService.GetStreetFileNmae(_folder);
            if (!File.Exists(file))
                throw new FileNotFoundException(string.Format("Не найден файл адресного классификатора {0}", file));

            var connection =
                new OleDbConnection(
                    string.Format(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=DBASE IV;Persist Security Info=False;",
                        _folder));
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText =
                string.Format(
                    "SELECT [name], [code], [socr], LEFT([code],2) as TrimCode FROM kladr where [code] LIKE '%00000000000'");
            command.CommandType = CommandType.Text;
            var result = new List<Territory>();
            using (var dataReader = command.ExecuteReader())
                while (dataReader.Read())
                    result.Add(new Territory
                    {
                        Code = dataReader["code"].ToString(),
                        Contraction = dataReader["socr"].ToString(),
                        Name = dataReader["name"].ToString(),
                        TrimCode = dataReader["TrimCode"].ToString()
                    });
            return result;
        }
    }
}