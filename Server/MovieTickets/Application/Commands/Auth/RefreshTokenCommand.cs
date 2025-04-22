using Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Auth
{
    public class RefreshTokenCommand : IRequest<ResponseModel<LoginResponse>>
    {
        public string RefreshToken { get; set; }
    }
}
