using System.Diagnostics;

namespace RestaurantAPI.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _logger;
        private Stopwatch _stopwatch;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> logger)
        {
            _stopwatch = new Stopwatch();
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stopwatch.Start();
             await next.Invoke(context);
            _stopwatch.Stop();

            var elapsedMilisecounds = _stopwatch.ElapsedMilliseconds;
            if(elapsedMilisecounds / 1000 > 4)
            {
                var message = $"Request[{context.Request.Method}] at {context.Request.Path} took {elapsedMilisecounds} ms";
                _logger.LogInformation(message);
            }
        }
    }
}
