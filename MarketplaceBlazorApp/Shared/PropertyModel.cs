namespace MarketplaceBlazorApp.Shared
{
    public class PropertyModel
    {
        private int propertyID;
        private string propertyName;
        private string type;
        private int categoryID;

        public int PropertyID { get => propertyID; set => propertyID = value; }
        public string PropertyName { get => propertyName; set => propertyName = value; }
        public string Type { get => type; set => type = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
    }
}
