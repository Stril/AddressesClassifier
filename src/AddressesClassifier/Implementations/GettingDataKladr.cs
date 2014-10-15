using System.Linq;
using AddressesClassifier.Interfaces;
using AddressesClassifier.Models;

namespace AddressesClassifier.Implementations
{
    internal class GettingDataKladr : IGettingDataKladr
    {
        public IQueryable<Region> GetTerritories(IQueryable<Region> inputQueryable)
        {
            return inputQueryable.Where(p => p.Code.EndsWith("00000000000"));
        }

        public IQueryable<Region> GeTerritoriesByRegion(IQueryable<Region> inputQueryable, string code)
        {
            return
                inputQueryable.Where(
                    p =>
                        p.Code.StartsWith(code.Remove(2)) && p.Code.EndsWith("00") &&
                        ((p.Code[8] == '0' && p.Code[9] == '0' && p.Code[10] == '0') &&
                         (p.Code[5] != '0' || p.Code[6] != '0' || p.Code[7] != '0')));
        }

        public IQueryable<Region> GetDistrictByRegion(IQueryable<Region> inputQueryable, string code)
        {
            return
                inputQueryable.Where(
                    p =>
                        p.Code.StartsWith(code.Remove(2)) && p.Code.EndsWith("00") && p.Code != code &&
                        ((p.Code[8] == '0' && p.Code[9] == '0' && p.Code[10] == '0') &&
                         (p.Code[5] == '0' && p.Code[6] == '0' && p.Code[7] == '0')));
        }

        public IQueryable<Region> GetTownByRegion(IQueryable<Region> inputQueryable, string code)
        {
            return
                inputQueryable.Where(
                    p =>
                        p.Code.StartsWith(code.Remove(2)) && p.Code.EndsWith("00") &&
                        (((p.Code[8] == '0' && p.Code[9] == '0' && p.Code[10] == '0') &&
                          (p.Code[5] != '0' || p.Code[6] != '0' || p.Code[7] != '0')) ||
                         ((p.Code[2] != '0' || p.Code[3] != '0' || p.Code[4] != '0') &&
                          (p.Code[8] != '0' || p.Code[9] != '0' || p.Code[10] != '0')) ||
                         ((p.Code[8] != '0' || p.Code[9] != '0' || p.Code[10] != '0') &&
                          ((p.Code[2] == '0' && p.Code[3] == '0' && p.Code[4] == '0' && p.Code[5] == '0' &&
                            p.Code[6] == '0' && p.Code[7] == '0')))));
        }

        public IQueryable<Region> GetSettlementTownsByCity(IQueryable<Region> inputQueryable, string code)
        {
            return
                inputQueryable.Where(
                    p =>
                        p.Code.StartsWith(code.Remove(8)) && p.Code.EndsWith("00") &&
                        (p.Code[8] != '0' || p.Code[9] != '0' || p.Code[10] != '0'));
        }

        public IQueryable<Region> GetTownsByRegion(IQueryable<Region> inputQueryable, string code)
        {
            return
                inputQueryable.Where(
                    p =>
                        p.Code.StartsWith(code.Remove(5)) && p.Code.EndsWith("00") &&
                        (((p.Code[8] != '0' || p.Code[9] != '0' || p.Code[10] != '0') &&
                          (p.Code[5] == '0' && p.Code[6] == '0' && p.Code[7] == '0')) ||
                         ((p.Code[8] == '0' && p.Code[9] == '0' && p.Code[10] == '0') &&
                          (p.Code[5] != '0' || p.Code[5] != '0' || p.Code[7] != '0'))));
        }

        public IQueryable<Street> GetStreets(IQueryable<Street> inputQueryable, string code)
        {
            return inputQueryable.Where(p => p.Code.StartsWith(code.Remove(11)) && p.Code.EndsWith("00"));
        }

        public IQueryable<Street> GetStreetsByRegion(IQueryable<Street> inputQueryable, string code)
        {
            return inputQueryable.Where(p => p.Code.StartsWith(code.Remove(11)) && p.Code.EndsWith("00"));
        }
    }
}