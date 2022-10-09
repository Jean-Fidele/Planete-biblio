using Facade.Contact;
using Hangfire;
using MediatR;

namespace Synchonisation.Job
{
    public class JobsToRead
    {
        private readonly IServiceProvider _serviceProvider;

        public JobsToRead(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [DisableConcurrentExecution(timeoutInSeconds: 60 * 60)]
        public async Task EveryNights()
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            await mediator.Send(new GetContact.Request
            {
                  
            });
        }

        [DisableConcurrentExecution(timeoutInSeconds: 20 * 60)]
        public async Task EveryTwoHours()
        {
            using var scope = _serviceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            await mediator.Send(new GetContact.Request
            {
            });
        }
    }
}


