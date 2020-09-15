using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAPI.Models
{
  public class ApiRoutes
  {

    public const string Api = "Api";
    public const string Controller = "[controller]";
    public const string Base = Api + "/" + Controller;

    public const string AuthScheme = JwtBearerDefaults.AuthenticationScheme;

    public static class Auth
    {
      public const string SignIn = "SignIn";
      public const string SignUp = "SignUp";
      public const string CheckByUserName = "CheckByUserName";
    }

    public static class Shop
    {
      public const string AddGameServer = "AddGameServer";
      public const string EditGameServer = "EditGameServer";
      public const string RemoveGameServer = "DeleteGameServer";
      public const string GetGameServers = "GetGameServers";

      public const string AddCategory = "AddCategory";
      public const string EditCategory = "EditCategory";
      public const string RemoveCategory = "DeleteCategory";
      public const string GetCategories = "GetCategories";

      public const string AddItem = "AddItem";
      public const string EditItem = "EditItem";
      public const string RemoveItem = "DeleteItem";
      public const string GetItems = "GetItems";
    }

  }
}
