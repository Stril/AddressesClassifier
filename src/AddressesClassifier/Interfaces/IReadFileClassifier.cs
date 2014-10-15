using System.Collections.Generic;
using System.Data;
using System.IO;
using AddressesClassifier.Models;

namespace AddressesClassifier.Interfaces
{
    /// <summary>
    /// Чтение файла классификатора адресов
    /// </summary>
    public interface IReadFileClassifier
    {
        /// <summary>
        /// Чтение данных по региону
        /// </summary>
        /// <param name="code">Код региона</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <returns></returns>
        DataTable ReadRegion(string code);
        /// <summary>
        /// Чтение данных по всем регионам
        /// </summary>
        /// <returns></returns>
        DataTable ReadAllRegions();
        /// <summary>
        /// Чтение данных по улицам региона
        /// </summary>
        /// <param name="code">Код региона</param>
        /// <returns></returns>
        DataTable ReadStreetsByRegion(string code);
        /// <summary>
        /// Чтение данных по улицам
        /// </summary>
        /// <returns></returns>
        DataTable ReadAllStreets();
        /// <summary>
        /// Чтение наименований регионов и их кодов
        /// </summary>
        /// <returns></returns>
        DataTable ReadBaseInfo();
        /// <summary>
        /// Чтение данных по региону
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<Region> ReadRegionModel(string code);
        /// <summary>
        /// Чтение данных по всем регионам
        /// </summary>
        /// <returns></returns>
        IEnumerable<Region> ReadAllRegionsModel();
        /// <summary>
        /// Чтение данных по улицам региона
        /// </summary>
        /// <param name="code">Код региона</param>
        /// <returns></returns>
        IEnumerable<Street> ReadStreetsByRegionModel(string code);
        /// <summary>
        /// Чтение данных по улицам
        /// </summary>
        /// <returns></returns>
        IEnumerable<Street> ReadAllStreetsModel();
        /// <summary>
        /// Чтение наименований регионов и их кодов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Territory> ReadBaseInfoModel();
    }
}