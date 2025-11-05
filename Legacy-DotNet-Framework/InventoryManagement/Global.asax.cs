using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InventoryManagement
{
    /// <summary>
    /// Legacy Global Application Class - .NET Framework 4.5 pattern
    /// Shows outdated application startup and configuration
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Legacy: Basic route registration
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            // Legacy: No dependency injection container
            // Legacy: No modern middleware pipeline
            // Legacy: Limited configuration options
            
            // Legacy: Manual database initialization
            System.Data.Entity.Database.SetInitializer(
                new System.Data.Entity.CreateDatabaseIfNotExists<Models.InventoryContext>());
        }

        protected void Application_Error()
        {
            // Legacy: Basic error handling
            Exception exception = Server.GetLastError();
            
            // Legacy: Simple logging to event log
            if (exception != null)
            {
                System.Diagnostics.EventLog.WriteEntry("InventoryManagement", 
                    exception.ToString(), 
                    System.Diagnostics.EventLogEntryType.Error);
            }
        }

        protected void Session_Start()
        {
            // Legacy: Session-based state management
            Session["StartTime"] = DateTime.Now;
        }

        protected void Application_BeginRequest()
        {
            // Legacy: No modern request pipeline
            // Legacy: No middleware for cross-cutting concerns
        }

        protected void Application_EndRequest()
        {
            // Legacy: Basic request cleanup
        }
    }
}