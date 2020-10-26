using System.Collections.Generic;

namespace Entities
{
    public class Constants
    {
        public const string DBSERVER = "DBSERVER";       
        public const string ConnectionString = "ConnectionString";

        #region USERSUBSCRIPTION
        #region PROCS
        public const string sp_UserBook_Get_By_Id = "sp_UserBook_Get_By_Id";
        public const string sp_UserBook_Get_By_UserId = "sp_UserBook_Get_By_UserId";
        public const string sp_UserBook_Get_By_BookId = "sp_UserBook_Get_By_BookId";
        public const string sp_UserBook_Get = "sp_UserBook_Get";
        public const string sp_UserBook_Get_All = "sp_UserBook_Get_All";
        public const string sp_UserBook_Insert = "sp_UserBook_Insert";
        public const string sp_UserBook_Update = "sp_UserBook_Update";
        public const string sp_UserBook_Delete = "sp_UserBook_Delete"; 
        #endregion
        #endregion
        #region BOOK
        #region PROCS
        public const string sp_Book_Insert = "sp_Book_Insert";
        public const string sp_Book_Update = "sp_Book_Update";
        public const string sp_Book_Delete = "sp_Book_Delete";
        public const string sp_Book_Get_All = "sp_Book_Get_All";
        public const string sp_Book_Get_By_Id = "sp_Book_Get_By_Id";
        public const string sp_Book_Get_By_UserId = "sp_Book_Get_By_UserId";
        public const string sp_Book_Select_All = "sp_Book_Select_All"; 
        #endregion
        public const string BookId = "BookId";
        public const string Text = "Text";
        public const string Name = "Name";
        public const string PurchasePrice = "PurchasePrice";
        #endregion
        #region USER
        #region PROCS
        public const string sp_User_Get_All = "sp_User_Get_All";
        public const string sp_User_Get_By_Id = "sp_User_Get_By_Id";
        public const string sp_User_Insert = "sp_User_Insert";
        public const string sp_User_Update = "sp_User_Update";
        public const string sp_User_Delete = "sp_User_Delete";
        public const string sp_User_Select_All = "sp_User_Select_All"; 
        #endregion
        public const string UserId = "UserId";
        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const string EmailAddress = "EmailAddress";
        #endregion
        #region GLOBAL
        public const string Id = "Id";     
        public const string IsActive = "IsActive";
        public const string IsDeleted = "IsDeleted";
        public const string CreatedDate = "CreatedDate";
        public const string UpdatedDate = "UpdatedDate";
        public const string CreatedBy = "CreatedBy";
        public const string UpdatedBy = "UpdatedBy";
        #endregion
        #region MESSAGES
        public const string Insert = "Insert {0}";
        public const string Update = "Update {0}";
        public const string Delete = "Delete {0}";
        public const string Upload = "Upload {0} {1}";
        public const string Successful = "Successful";
        public const string UserName_or_Password_is_incorrect = "UserName or Password is incorrect";

        public const string Failed = "Failed";
        public const string Failed_0 = "Failed {0}";
        #endregion
        #region HEADERS
        public const string SwaggerDocumentTitle = "Book Subscription Web API";
        #endregion
        #region CONFIGSETTINGS
        public const string ApplicationSettings_JWT_Secret = "ApplicationSettings:JWT_Secret";
        public const string AccessConnection = "AccessConnection";
        #endregion
    }
}
