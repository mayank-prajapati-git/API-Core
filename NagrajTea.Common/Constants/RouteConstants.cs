using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagrajTea.Common.Constants
{
    public static class RouteConstants
    {
        public static class ProductCategory
        {
            public const string GetProductCategory = "GetProductCategory";
            public const string GetProductCategoryById = "GetProductCategoryById/{id:Guid}";
            public const string CreateProductCategory = "CreateProductCategory";
            public const string UpdateProductCategory = "UpdateProductCategory";
            public const string UpdateProductCategoryStatus = "UpdateProductCategoryStatus";
            public const string GetActiveCategoryList = "GetActiveCategoryList";
        }

        public static class Account
        {
            public const string Login = "Login";
        }
        public static class User
        {
            public const string GetUserList = "GetUserList";
            public const string GetUserDetail = "GetUserDetail";
            public const string SaveUser = "SaveUser";
        }
    }
}
