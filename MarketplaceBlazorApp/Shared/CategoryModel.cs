using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceBlazorApp
{
    public class CategoryModel
    {
        private int categoryID;
        private string categoryName;
        private int parentCategoryID;

        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public int ParentCategoryID { get => parentCategoryID; set => parentCategoryID = value; }
        public virtual ICollection<CategoryModel> SubCategories { get; set; }
    }
}
