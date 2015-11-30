namespace OwinWebAPIMono
{
    using System;
    using System.Web.Http;
    using Microsoft.Owin.Hosting;
    using Newtonsoft.Json.Serialization;
    using Owin;

    public class Startup
    {
        private IDisposable app;

        public void Start()
        {
            app = WebApp.Start<Startup>(Config.Endpoint);
        }

        public void Stop()
        {
            app.Dispose();
            app = null;
        }
        
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration
            {
                IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always
            };

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("NotFound", "{*uri}", new {controller = "Errors"});
            appBuilder.UseWebApi(config);
            config.EnsureInitialized();
        }
    }
}