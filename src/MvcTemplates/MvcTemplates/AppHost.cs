using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Funq;
using ServiceStack;
using ServiceStack.Mvc;
using MvcTemplates.ServiceInterface;


namespace MvcTemplates
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("MvcTemplates", typeof(MyServices).Assembly) { }

        static Dictionary<string, string> DocLinks = new Dictionary<string, string>
        {
            { "installation", "Installation"},
            { "introduction", "Introduction"},
            { "syntax", "Syntax"},
            { "page-formats", "Page Formats"},
            { "arguments", "Arguments"},
            { "filters", "Filters"},
            { "default-filters", "Default Filters"},
            { "partials", "Partials"},
            { "protected-filters", "Protected Filters"},
            { "transformers", "Transformers"},
            { "view-engine", "View Engine"},
            { "model-view-controller", "Model View Controller"},
            { "code-pages", "Code Pages"},
            { "mvc-netcore", "ASP.NET Core MVC"},
            { "mvc-aspnet", "ASP.NET v4.5 MVC"},
            { "sandbox", "Sandbox"},
            { "api-reference", "API Reference"},
        };

        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                HandlerFactoryPath = "api",
            });

            var customFilters = new CustomTemplateFilters();

            var i = 1;
            DocLinks.ForEach((page, title) => customFilters.DocsIndex[i++] = new KeyValuePair<string, string>(
                "http://templates.servicestack.net/docs/" + page,
                title
            ));

            Plugins.Add(new TemplatePagesFeature
            {
                TemplateFilters = { customFilters }
            });

            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
        }
    }
}