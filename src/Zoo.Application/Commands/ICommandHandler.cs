using System.Threading.Tasks;

namespace Zoo.Application.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
} 