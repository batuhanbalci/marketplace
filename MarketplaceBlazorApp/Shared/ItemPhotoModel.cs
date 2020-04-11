namespace MarketplaceBlazorApp
{
    public class ItemPhotoModel
    {
        private int photoID;
        private string path;
        private int itemID;

        public int PhotoID { get => photoID; set => photoID = value; }
        public string Path { get => path; set => path = value; }
        public int ItemID { get => itemID; set => itemID = value; }
    }
}
