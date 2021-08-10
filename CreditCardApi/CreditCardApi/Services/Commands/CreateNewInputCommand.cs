using CreditCardApi.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardApi.Services.Commands
{
    public class CreateNewInputCommand : IRequest<Input>
    {
        public Input NewInput { get; set; }
    }

}
