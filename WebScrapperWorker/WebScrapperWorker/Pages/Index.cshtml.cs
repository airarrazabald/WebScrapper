using Hangfire;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebScrapperWorker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public IndexModel(ILogger<IndexModel> logger, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _logger = logger;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        public void OnGet()
        {
            _backgroundJobClient.Enqueue(() => CalledFromBackground());
            _recurringJobManager.AddOrUpdate("MyJOb", () => Console.WriteLine("Hola Mundo 111"), "* * * * *");
        }

        public void CalledFromBackground()
        {
            var numbre1 = 2;
            var number2 = 2;

            var sum = numbre1 + number2;

            Console.WriteLine($"The sum of two Number is {sum}");
        }
    }
}