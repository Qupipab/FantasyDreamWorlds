using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
  public class ApiRoutes
  {

    public const string Api = "api";
    public const string Controller = "[controller]";
    public const string Base = Api + "/" + Controller;

    public static class Auth
    {
      public const string SignIn = "SignIn";
      public const string SignUp = "SignUp";
    }

  }
}
