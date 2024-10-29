namespace Workshop_1.Middlewares
{
    public class CacheControlMiddleware
    {
        private readonly RequestDelegate _next;

        public CacheControlMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value ?? string.Empty;

            // Example: Set different cache control headers based on route
            if (path.Contains("/public"))
            {
                SetCacheHeaders(context, "public", 120); // 120 seconds for public routes
            }
            else if (path.Contains("/private"))
            {
                SetCacheHeaders(context, "private", 60); // 60 seconds for private routes
            }
            else if (path.Contains("/no-cache"))
            {
                SetCacheHeaders(context, "no-cache", 60); // 60 seconds for no-cache routes
            }

            await _next(context);
        }

        private void SetCacheHeaders(HttpContext context, string cacheControl, int maxAge)
        {
            context.Response.Headers["Cache-Control"] = $"{cacheControl}, max-age={maxAge}";
            context.Response.Headers["Expires"] = DateTime.UtcNow.AddSeconds(maxAge).ToString("R");
        }
    }
}
