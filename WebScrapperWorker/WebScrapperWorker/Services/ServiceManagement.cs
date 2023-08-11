namespace WebScrapperWorker.Services
{
    public class ServiceManagement : IServiceManagement
    {
        public async Task GetMessage()
        {
           await Task.Run(() => Console.WriteLine($"Generate Merchandise: long running service at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}"));
        }
    }
}
