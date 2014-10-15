using System.Linq;
using AddressesClassifier.Models;

namespace AddressesClassifier.Interfaces
{
    /// <summary>
    /// Получение данных из классификатора Кладр
    /// </summary>
    public interface IGettingDataKladr
    {
        /// <summary>
        /// Получение списка регионов и федеральных городов
        /// </summary>
        /// <param name="inputQueryable"></param>
        /// <returns></returns>
        IQueryable<Region> GetTerritories(IQueryable<Region> inputQueryable);

        /// <summary>
        /// Получение населенного пункта по коду региона
        /// </summary>
        /// <param name="inputQueryable"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        IQueryable<Region> GeTerritoriesByRegion(IQueryable<Region> inputQueryable, string code);

        /// <summary>
        /// Получение административного района по региону
        /// </summary>
        /// <param name="inputQueryable"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        IQueryable<Region> GetDistrictByRegion(IQueryable<Region> inputQueryable, string code);

        /// <summary>
        /// Получение всех населенных пунктов (за исключением подчиненных городу) по коду региона
        /// </summary>
        /// <param name="inputQueryable"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        IQueryable<Region> GetTownByRegion(IQueryable<Region> inputQueryable, string code);

        /// <summary>
        /// Получение подчиненных нас пунктов текущему городу
        /// </summary>
        /// <param name="inputQueryable"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        IQueryable<Region> GetSettlementTownsByCity(IQueryable<Region> inputQueryable, string code);

        /// <summary>
        /// Получение всех населенных пунктов по региону
        /// </summary>
        /// <param name="inputQueryable"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        IQueryable<Region> GetTownsByRegion(IQueryable<Region> inputQueryable, string code);

        /// <summary>
        /// Получение списка улиц по коду населенного пункта
        /// </summary>
        /// <param name="inputQueryable"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        IQueryable<Street> GetStreets(IQueryable<Street> inputQueryable, string code);

        /// <summary>
        /// Получение улиц по региону, федеральному городу
        /// </summary>
        /// <param name="inputQueryable"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        IQueryable<Street> GetStreetsByRegion(IQueryable<Street> inputQueryable, string code);
    }
}
