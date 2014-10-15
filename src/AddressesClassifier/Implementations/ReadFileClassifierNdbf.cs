using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using AddressesClassifier.Interfaces;
using AddressesClassifier.Models;
using AddressesClassifier.Services;
using NDbfReaderEx;

namespace AddressesClassifier.Implementations
{
    internal class ReadFileClassifierNdbf : IReadFileClassifier
    {
        private readonly string _folder;

        public ReadFileClassifierNdbf(string folder)
        {
            _folder = folder;
        }

        public DataTable ReadRegion(string code)
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!FileService.CheckKladrFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);

            var dataTable = DataService.GetDataTableStandart();
            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
            using (var data = table.AsDataTable())
                foreach (var dataRow in data.Select("CODE LIKE '" + code + "%'"))
                    dataTable.ImportRow(dataRow);
            return dataTable;
        }

        public DataTable ReadAllRegions()
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!FileService.CheckKladrFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);
            DataTable dataTable;
            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
                dataTable = table.AsDataTable();
            return dataTable;
        }

        public DataTable ReadStreetsByRegion(string code)
        {
            var file = FileService.GetStreetFileNmae(_folder);
            if (!FileService.CheckStreetFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);

            var dataTable = DataService.GetDataTableStandart();
            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
            using (var data = table.AsDataTable())
                foreach (var dataRow in data.Select("CODE LIKE '" + code + "%'"))
                    dataTable.ImportRow(dataRow);
            return dataTable;

        }

        public DataTable ReadAllStreets()
        {
            var file = FileService.GetStreetFileNmae(_folder);
            if (!FileService.CheckKladrFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);
            DataTable dataTable;
            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
                dataTable = table.AsDataTable();
            return dataTable;
        }

        public DataTable ReadBaseInfo()
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!FileService.CheckKladrFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);

            var dataTable = DataService.GetDataTableBase();
            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
            using (var data = table.AsDataTable())
                foreach (var dataRow in data.Select("code LIKE '%00000000000'"))
                    dataTable.ImportRow(dataRow);

            for (var i = 0; i < dataTable.Rows.Count; i++)
                dataTable.Rows[i]["trimcode"] = dataTable.Rows[i]["code"].ToString().Substring(0, 2);
            return dataTable;
        }

        public IEnumerable<Region> ReadRegionModel(string code)
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!FileService.CheckKladrFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);

            var result = new List<Region>();

            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
            using (var data = table.AsDataTable())
                foreach (var dataRow in data.Select("CODE LIKE '" + code + "%'"))
                    result.Add(new Region
                    {
                        Code = dataRow["code"].ToString(),
                        Contraction = dataRow["socr"].ToString(),
                        Name = dataRow["name"].ToString(),
                        PostIndex = dataRow["index"].ToString()
                    });
            return result;
        }

        public IEnumerable<Region> ReadAllRegionsModel()
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!FileService.CheckKladrFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);

            var result = new List<Region>();
            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
            using (var data = table.AsDataTable())
                foreach (var dataRow in data.Select())
                    result.Add(new Region
                    {
                        Code = dataRow["code"].ToString(),
                        Contraction = dataRow["socr"].ToString(),
                        Name = dataRow["name"].ToString(),
                        PostIndex = dataRow["index"].ToString()
                    });
            return result;
        }

        public IEnumerable<Street> ReadStreetsByRegionModel(string code)
        {
            var file = FileService.GetStreetFileNmae(_folder);
            if (!FileService.CheckStreetFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);

            var result = new List<Street>();
            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
            using (var data = table.AsDataTable())
                foreach (var dataRow in data.Select("CODE LIKE '" + code + "%'"))
                {
                    result.Add(new Street
                    {
                        Code = dataRow["code"].ToString(),
                        Contraction = dataRow["socr"].ToString(),
                        Name = dataRow["name"].ToString(),
                        PostIndex = dataRow["index"].ToString()
                    });
                }
            return result;
        }

        public IEnumerable<Street> ReadAllStreetsModel()
        {
            var file = FileService.GetStreetFileNmae(_folder);
            if (!FileService.CheckStreetFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);

            var result = new List<Street>();
            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
            using (var data = table.AsDataTable())
                foreach (var dataRow in data.Select())
                {
                    result.Add(new Street
                    {
                        Code = dataRow["code"].ToString(),
                        Contraction = dataRow["socr"].ToString(),
                        Name = dataRow["name"].ToString(),
                        PostIndex = dataRow["index"].ToString()
                    });
                }
            return result;
        }

        public IEnumerable<Territory> ReadBaseInfoModel()
        {
            var file = FileService.GetKladrFileName(_folder);
            if (!FileService.CheckKladrFile(_folder))
                throw new FileNotFoundException("Не найден файл адресного классификатора " + _folder);

            var result = new List<Territory>();
            var dataTable = DataService.GetDataTableBase();
            using (var table = DbfTable.Open(file, Encoding.GetEncoding(866)))
            using (var data = table.AsDataTable())
                foreach (var dataRow in data.Select("code LIKE '%00000000000'"))
                    dataTable.ImportRow(dataRow);
            for (var i = 0; i < dataTable.Rows.Count; i++)
                dataTable.Rows[i]["trimcode"] = dataTable.Rows[i]["code"].ToString().Substring(0, 2);
            foreach (var dataRow in dataTable.Select())
            {
                result.Add(new Territory
                {

                    Code = dataRow["code"].ToString(),
                    Contraction = dataRow["socr"].ToString(),
                    Name = dataRow["name"].ToString(),
                    TrimCode = dataRow["trimcode"].ToString()
                });
            }
            return result;
        }
    }
}