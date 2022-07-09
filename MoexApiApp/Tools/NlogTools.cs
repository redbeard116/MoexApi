namespace MoexApiApp.Tools
{
    public static class NlogTools
    {
        public static void AddNlogLogger()
        {
            var nlogConfig = new NLog.Config.XmlLoggingConfiguration(@"Configs/NlogConfig.xml");

            NLog.LogManager.Configuration = nlogConfig;
        }
    }
}
