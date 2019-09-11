using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Zoo.Application.Commands;

namespace Zoo.Infrastructure.Dispatchers
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetService<ICommandHandler<TCommand>>();
            return handler.HandleAsync(command);
        }
    }
}