using Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Auth
{
    public class LoginCommand : IRequest<ResponseModel<LoginResponse>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
