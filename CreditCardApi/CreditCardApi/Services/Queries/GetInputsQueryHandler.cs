using CreditCardApi.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CreditCardApi.Services.Queries
{
    public class GetInputsQueryHandler : IRequestHandler<GetInputsQuery, List<Input>>
    {
        private readonly IInputService _inputService;
        public GetInputsQueryHandler(IInputService inputService)
        {
            _inputService = inputService;
        }

        public async Task<List<Input>> Handle(GetInputsQuery request, CancellationToken cancellationToken)
        {
            return (await _inputService.GetAllInputs()).ToList();
        }
    }

}
