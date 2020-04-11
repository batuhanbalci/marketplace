using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceBlazorApp
{
    public class ItemModel
    {
        private int itemID;
        private string title;
        private string description;
        private int categoryID; //??
        private int userID;
        private decimal price;
        private string state;
        private DateTime releaseDate;
        private int clickCount;
        private int neighborhoodID;
        private decimal mapX;
        private decimal mapY;
        private List<ItemPhotoModel> itemPhotos;
        private string profilePhotoPath;

        public int ItemID { get => itemID; set => itemID = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public int UserID { get => userID; set => userID = value; }
        public decimal Price { get => price; set => price = value; }
        public string State { get => state; set => state = value; }
        public DateTime ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public int ClickCount { get => clickCount; set => clickCount = value; }
        public int NeighborhoodID { get => neighborhoodID; set => neighborhoodID = value; }
        public decimal MapX { get => mapX; set => mapX = value; }
        public decimal MapY { get => mapY; set => mapY = value; }
        public List<ItemPhotoModel> ItemPhotos { get => itemPhotos; set => itemPhotos = value; }
        public string ProfilePhotoPath { get => profilePhotoPath; set => profilePhotoPath = value; }
    }
}
