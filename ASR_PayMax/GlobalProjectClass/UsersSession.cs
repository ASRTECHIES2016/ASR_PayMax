//using ASR_CommonLogic.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using ASR_PayMaxLogic.Models;

namespace ASR_PayMax.GlobalProjectClass
{
    public class UsersSession
    {
        public static void GetMessages(Page _Page, string Status, string Message)
        {
            switch (Status)
            {
                case "Success":
                    ScriptManager.RegisterStartupScript(_Page, _Page.GetType(), "Success", "ShowSuccess('" + Message + "');", true);
                    break;
                case "Warning":
                    ScriptManager.RegisterStartupScript(_Page, _Page.GetType(), "Warning", "ShowWarning('" + Message + "');", true);
                    break;
                case "Failure":
                    ScriptManager.RegisterStartupScript(_Page, _Page.GetType(), "Failure", "ShowFailure('" + Message + "');", true);
                    break;                    
                case "Error":
                    ScriptManager.RegisterStartupScript(_Page, _Page.GetType(), "Error", "ShowError('" + Message + "');", true);
                    break;
            }

        }

        public static ASR_PayMaxParameters GetSession()
        {
            return (ASR_PayMaxParameters)HttpContext.Current.Session["UserDetails"];
          
        }

        public static void SetSession(ASR_PayMaxParameters user)
        {
            HttpContext.Current.Session["UserDetails"] = user;
            if (user != null)
            {
                HttpContext.Current.Session.Timeout = Convert.ToInt32(user.Str_SessionTimeOut);
            }
        }

    }
    public class WebConnectionString
    {
        public static string getConnction(string UserType)
        {
            string Key = "";
            string Conn = "";
            switch (UserType)
            {
                case "Admin":
                    Key = ConfigurationManager.AppSettings["Admin"];
                    Conn = ConfigurationManager.ConnectionStrings["SqlAdminConnString"].ConnectionString.ToString();
                    break;
                case "Client":
                    Key = ConfigurationManager.AppSettings["Client"];
                    Conn = ConfigurationManager.ConnectionStrings["SqlClientConnString"].ConnectionString.ToString();
                    break;
                case "User":
                    Key = ConfigurationManager.AppSettings["User"];
                    Conn = ConfigurationManager.ConnectionStrings["SqlUserConnString"].ConnectionString.ToString();
                    break;
            }
            return Key + "," + Conn;
        }
    }

}