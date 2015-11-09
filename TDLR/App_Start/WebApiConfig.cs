﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Tdlr
{
    public static class WebApiConfig
    {
        // Configure the routes for the Web API
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetAssignments",
                routeTemplate: "api/admin/users",
                defaults: new { controller = "AdminApi", action = "GetAssignedUsers" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "ClearUsers",
                routeTemplate: "api/admin/users/clear",
                defaults: new { controller = "AdminApi", action = "ClearUserTable" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "UpdateApi",
                routeTemplate: "api/tasks/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "TasksApi", action = "Update" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            config.Routes.MapHttpRoute(
                name: "DeleteApi",
                routeTemplate: "api/tasks/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "TasksApi", action = "Delete" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Delete) }
            );

            config.Routes.MapHttpRoute(
                name: "CreateApi",
                routeTemplate: "api/tasks",
                defaults: new { controller = "TasksApi", action = "Create" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) }
            );

            config.Routes.MapHttpRoute(
                name: "ShareApi",
                routeTemplate: "api/tasks/{id}/share",
                defaults: new { id = RouteParameter.Optional, controller = "TasksApi", action = "UpdateShares" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Put) }
            );

            config.Routes.MapHttpRoute(
                name: "ShareGetApi",
                routeTemplate: "api/tasks/{id}/share",
                defaults: new { id = RouteParameter.Optional, controller = "TasksApi", action = "GetShares" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "GetAllApi",
                routeTemplate: "api/tasks",
                defaults: new { id = RouteParameter.Optional, controller = "TasksApi", action = "GetAll" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "GetApi",
                routeTemplate: "api/tasks/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "TasksApi", action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/tasks/{id}",
                defaults: new { id = RouteParameter.Optional, controller = "TasksApi" }
            );

            // Force that we'll always return JSON from the API
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
        }
    }
}
