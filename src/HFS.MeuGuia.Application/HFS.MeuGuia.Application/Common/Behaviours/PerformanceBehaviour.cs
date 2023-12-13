using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace HFS.MeuGuia.Application.Common.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly Stopwatch _timer;
        private const int MaxElapsedInMilliseconds = 500;
        private readonly ILogger<PerformanceBehaviour<TRequest, TResponse>> _logger;

        public PerformanceBehaviour(ILogger<PerformanceBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger;
            _timer = new Stopwatch();

        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds <= MaxElapsedInMilliseconds)
                return response;

            var requestName = typeof(TRequest).Name;

            _logger.LogWarning("MeuGuia demorou muito para responder: {Request} {ElapsedMilliseconds}ms {@Request}",
                requestName, elapsedMilliseconds, request);

            return response;
        }
    }
}
