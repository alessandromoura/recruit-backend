using CreditCardApi.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CreditCardApi.Services.Queries
{
    public class GetInputByIdQueryHandler : IRequestHandler<GetInputByIdQuery, Input>
    {
        private readonly IInputService _inputService;
        public GetInputByIdQueryHandler(IInputService inputService)
        {
            _inputService = inputService;
        }

        public async Task<Input> Handle(GetInputByIdQuery request, CancellationToken cancellationToken)
        {
            return await _inputService.GetInputById(request.InputId);
        }
    }

}
