using CreditCardApi.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CreditCardApi.Services.Commands
{
    public class CreateNewInputCommandHandler : IRequestHandler<CreateNewInputCommand, Input>
    {
        private readonly IInputService _inputService;
        public CreateNewInputCommandHandler(IInputService inputService)
        {
            _inputService = inputService;
        }

        public async Task<Input> Handle(CreateNewInputCommand request, CancellationToken cancellationToken)
        {
            return await _inputService.AddNewInput(request.NewInput);
        }
    }

}
