using Dapper;
using MarketplaceBlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceBlazorApp.DataEngine
{
    public class CategoryDE
    {
        public static IEnumerable<CategoryModel> GetCategories(int parentCategoryID = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ParentCategoryID", parentCategoryID);
            return DapperORM.ReturList<CategoryModel>("CategoryGET", param);
        }

        public static void AddOrEdit(string categoryName, int parentCategoryID, int categoryID = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryName", categoryName);
            param.Add("@ParentCategoryID", parentCategoryID);

            if (categoryID == 0)
            {
                DapperORM.ExecuteWithoutReturn("CategorySET", param);
            }
            else
            {
                param.Add("@CategoryID", categoryID);
                DapperORM.ExecuteWithoutReturn("CategoryUPDATE", param);
            }
        }
    }
}
