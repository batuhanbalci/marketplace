using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MarketplaceBlazorApp.Server.DataEngine
{
    public class RegionDE
    {
        public IEnumerable<RegionCityModel> GetRegionCities()
        {
            return DapperORM.ReturList<RegionCityModel>("RegionCityGET");
        }

        public IEnumerable<RegionCountyModel> GetRegionCounties(int cityID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CityID", cityID);
            return DapperORM.ReturList<RegionCountyModel>("RegionCountyGET", param);
        }

        public IEnumerable<RegionDistrictModel> GetRegionDistricts(int countyID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CountyID", countyID);
            return DapperORM.ReturList<RegionDistrictModel>("RegionDistrictGET", param);
        }

        public IEnumerable<RegionNeighborhoodModel> GetRegionNeighborhoods(int districtID)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@DistrictID", districtID);
            return DapperORM.ReturList<RegionNeighborhoodModel>("RegionNeighborhoodGET", param);
        }
    }
}
