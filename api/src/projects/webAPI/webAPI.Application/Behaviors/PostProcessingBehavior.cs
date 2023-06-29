using Core.BackgroundJob.Services;
using MediatR;
using webAPI.Application.Features.Auths.Commands.Register;
using webAPI.Application.Jobs.FireAndForgetJobs;

namespace webAPI.Application.Behaviors
{
    public class PostProcessingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IJobService _jobService;

        public PostProcessingBehavior(IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            if (request is RegisterCommand registerCommand)
            {
                var email = registerCommand.UserForRegister.Email;
                _jobService.Enqueue<RegisterEmailJob>(x => x.Execute(email, registerCommand.UserForRegister.FirstName, registerCommand.UserForRegister.LastName));
            }

            return response;

        }
    }

}
