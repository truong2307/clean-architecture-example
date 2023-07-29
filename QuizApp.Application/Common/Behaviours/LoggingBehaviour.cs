using MediatR;
using Microsoft.Extensions.Logging;
using QuizApp.Application.Common.Interfaces;

namespace QuizApp.Application.Common.Behaviours
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger _logger;
        private readonly IClaimUserServices _claimUserServices;

        public LoggingBehavior(ILogger<TRequest> logger, IClaimUserServices claimUserServices)
        {
            _logger = logger;
            _claimUserServices = claimUserServices;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _claimUserServices.GetCurrentUserId() ?? string.Empty;
            string userName = _claimUserServices.GetCurrentUserName();

            _logger.LogInformation("Handling request: {Name} {@UserId} {@UserName}",
                requestName, userId, userName);

            var response = await next();
            _logger.LogInformation("{CommandName} handled", requestName);

            return response;
        }
    }
}
