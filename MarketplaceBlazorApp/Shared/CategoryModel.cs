using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceBlazorApp.Shared
{
    public class CategoryModel
    {
        public CategoryModel(int categoryID, string categoryName, int parentCategoryID)
        {
            this.CategoryID = categoryID;
            this.CategoryName = categoryName;
            this.ParentCategoryID = parentCategoryID;
        }

        public CategoryModel(string categoryName, int parentCategoryID)
        {
            this.CategoryName = categoryName;
            this.ParentCategoryID = parentCategoryID;
        }

        public CategoryModel() { }

        private int categoryID;
        private string categoryName;
        private int parentCategoryID;

        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public int ParentCategoryID { get => parentCategoryID; set => parentCategoryID = value; }
        //public virtual ICollection<CategoryModel> SubCategories { get; set; }
    }
}
