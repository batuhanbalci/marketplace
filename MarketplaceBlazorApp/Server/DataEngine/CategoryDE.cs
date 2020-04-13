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
        public async Task<IEnumerable<CategoryModel>> GetCategories(int parentCategoryID = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ParentCategoryID", parentCategoryID);
            return await DapperORM.ReturListAsync<CategoryModel>("CategoryGET", param);
        }

        public async Task AddOrEdit(CategoryModel category)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryName", category.CategoryName);
            param.Add("@ParentCategoryID", category.ParentCategoryID);

            if (category.CategoryID == 0)
            {
                await DapperORM.ExecuteWithoutReturnAsync("CategorySET", param);
            }
            else
            {
                param.Add("@CategoryID", category.CategoryID);
                await DapperORM.ExecuteWithoutReturnAsync("CategoryUPDATE", param);
            }
        }
    }
}
