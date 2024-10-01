using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NagrajTea.Common.Constants
{
    public static class DatabaseConstants
    {
        public static class Category
        {
            public const string GetCategoryList = "GetCategoryList";
            public const string GetCategoryDetails = "GetCategoryDetails";
            public const string CategoryUpsert = "CategoryUpsert";
            public const string ModifyCategory = "ModifyCategoryStatus";
            public const string GetActiveCategoryList = "GetActiveCategoryList";
        }

        public static class User
        {
            public const string USP_ValidateUser = "USP_ValidateUser";
            public const string USP_GetUserList = "USP_GetUserList";
            public const string USP_GetUserDetail = "USP_GetUserDetail";
        }
      
    }
}
