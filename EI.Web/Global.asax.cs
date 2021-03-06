﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using EI.Web.App_Start;
using System.Web.Optimization;

namespace EI.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var config = GlobalConfiguration.Configuration;

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(config);
            Bootstrapper.Run();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configuration.EnsureInitialized();
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
          
        }

        void Session_Start(object sender, EventArgs e)
        {
            Invoice inv = new Invoice(System.Web.HttpContext.Current.Session.SessionID);
            System.Web.HttpContext.Current.Session["Invoice"] = inv;
        }
    }
}