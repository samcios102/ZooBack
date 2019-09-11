using System.Threading.Tasks;

namespace Zoo.Application.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
} 