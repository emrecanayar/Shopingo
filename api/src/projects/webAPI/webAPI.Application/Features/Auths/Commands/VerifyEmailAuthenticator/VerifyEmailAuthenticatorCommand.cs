using Core.Domain.Entities;
using MediatR;
using webAPI.Application.Features.Auths.Rules;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.Auths.Commands.VerifyEmailAuthenticator
{
    public class VerifyEmailAuthenticatorCommand : IRequest
    {
        public string ActivationKey { get; set; }

        public class VerifyEmailAuthenticatorCommandHandler : IRequestHandler<VerifyEmailAuthenticatorCommand>
        {
            private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
            private readonly AuthBusinessRules _authBusinessRules;

            public VerifyEmailAuthenticatorCommandHandler(IEmailAuthenticatorRepository emailAuthenticatorRepository, AuthBusinessRules authBusinessRules)
            {
                _emailAuthenticatorRepository = emailAuthenticatorRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task Handle(VerifyEmailAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                EmailAuthenticator? emailAuthenticator = await _emailAuthenticatorRepository.GetAsync(x => x.ActivationKey == request.ActivationKey);
                await _authBusinessRules.EmailAuthenticatorShouldBeExists(emailAuthenticator);
                await _authBusinessRules.EmailAuthenticatorActivationKeyShouldBeExists(emailAuthenticator);

                emailAuthenticator.ActivationKey = null;
                emailAuthenticator.IsVerified = true;
                await _emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

                await Task.CompletedTask;
            }
        }
    }
}
