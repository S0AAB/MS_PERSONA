using System.Web.Http;

namespace MS_PERSONA
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
        
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutofacConfig.Register();
            
  
        }
    }
}
