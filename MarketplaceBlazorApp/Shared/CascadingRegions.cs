using System.Collections.Generic;

namespace MarketplaceBlazorApp.Shared
{
    public class RegionCityModel
    {
        private int cityID;
        private string city;

        public int CityID { get => cityID; set => cityID = value; }
        public string City { get => city; set => city = value; }
    }

    public class RegionCountyModel
    {
        private int countyID;
        private string county;
        private int cityID;

        public int CountyID { get => countyID; set => countyID = value; }
        public string County { get => county; set => county = value; }
        public int CityID { get => cityID; set => cityID = value; }
    }

    public class RegionDistrictModel
    {
        private int districtID;
        private string district;
        private int countyID;

        public int DistrictID { get => districtID; set => districtID = value; }
        public string District { get => district; set => district = value; }
        public int CountyID { get => countyID; set => countyID = value; }
    }

    public class RegionNeighborhoodModel
    {
        private int neighborhoodID;
        private string neighborhood;
        private string postcode;
        private int districtID;

        public int NeighborhoodID { get => neighborhoodID; set => neighborhoodID = value; }
        public string Neighborhood { get => neighborhood; set => neighborhood = value; }
        public string Postcode { get => postcode; set => postcode = value; }
        public int DistrictID { get => districtID; set => districtID = value; }
    }
}
