using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MarketplaceBlazorApp.Shared;

namespace MarketplaceBlazorApp.DataEngine
{
    public class PropertyDE
    {
        public async Task<IEnumerable<PropertyModel>> Get(int categoryID = 0, int propertyID = 0)
        {
            DynamicParameters param = new DynamicParameters();
            if (propertyID > 0)
            {
                param.Add("@PropertyID", propertyID);
            }
            param.Add("@CategoryID", categoryID);
            return await DapperORM.ReturListAsync<PropertyModel>("PropertyGET", param);
        }

        public async Task AddOrEdit(PropertyModel property)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@PropertyName", property.PropertyName);
            param.Add("@Type", property.Type);
            param.Add("@CategoryID", property.CategoryID);

            if (property.PropertyID > 0)
            {
                param.Add("@PropertyID", property.PropertyID);
                await DapperORM.ExecuteWithoutReturnAsync("PropertyUPDATE", param);
            }
            else
            {
                await DapperORM.ExecuteWithoutReturnAsync("PropertySET", param);
            }
        }
    }
}
