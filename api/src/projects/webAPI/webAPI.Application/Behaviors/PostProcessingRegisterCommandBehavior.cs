using Core.BackgroundJob.Services;
using MediatR;
using webAPI.Application.Features.Auths.Commands.Register;
using webAPI.Application.Jobs.FireAndForgetJobs;

namespace webAPI.Application.Behaviors
{
    public class PostProcessingRegisterCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IJobService _jobService;

        public PostProcessingRegisterCommandBehavior(IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            if (request is RegisterCommand registerCommand)
            {
                _jobService.Enqueue<RegisterEmailJob>(x => x.Execute(registerCommand));
            }

            return response;

        }

    }

}
