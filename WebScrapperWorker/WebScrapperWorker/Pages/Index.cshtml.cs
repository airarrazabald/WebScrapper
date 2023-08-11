using Hangfire;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebScrapperWorker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBackgroundJobClient _backgroundJobClient;

        public IndexModel(ILogger<IndexModel> logger, IBackgroundJobClient backgroundJobClient)
        {
            _logger = logger;
            _backgroundJobClient = backgroundJobClient;
        }

        public void OnGet()
        {
            _backgroundJobClient.Enqueue(() => CalledFromBackground());
        }

        public void CalledFromBackground()
        {
            var numbre1 = 2;
            var number2 = 2;

            var sum = numbre1 + number2;
            _logger.LogDebug($"The sum of two Number is {sum}");
            Console.WriteLine($"The sum of two Number is {sum}");
        }
    }
}