namespace OwinWebAPIMono
{
    using Topshelf;

    internal class Program
    {
        private static int Main()
        {
            var exitCode = HostFactory.Run(c =>
            {
                c.Service<Startup>(service =>
                {
                    service.ConstructUsing(() => new Startup());
                    service.WhenStarted(x => x.Start());
                    service.WhenStopped(x => x.Stop());
                })
                    .UseLinuxIfAvailable();
            });

            return (int) exitCode;
        }
    }
}