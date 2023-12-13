using MediatR.Pipeline;
using Microsoft.Extensions.Logging;


namespace HFS.MeuGuia.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : class
    {
        private readonly ILogger<LoggingBehaviour<TRequest>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("Meu Guia Request: {Name} {@Request}", requestName, request);
            await Task.CompletedTask;
        }
    }
}
