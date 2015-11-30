namespace OwinWebAPIMono
{
    using System.Configuration;

    public class Config
    {
        public static string Endpoint
		{
			get
			{ 
				return GetAppSetting("Endpoint");
			}
		}

        private static string GetAppSetting(string appSettingKey)
        {
            return ConfigurationManager.AppSettings[appSettingKey];
        }

        private static string GetConnectionString(string connectionStringName)
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
    }
}