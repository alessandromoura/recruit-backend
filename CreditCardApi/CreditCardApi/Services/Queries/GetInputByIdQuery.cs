using CreditCardApi.Domain.Models;
using MediatR;

namespace CreditCardApi.Services.Queries
{
    public class GetInputByIdQuery : IRequest<Input>
    {
        public string InputId { get; set; }
    }

}
