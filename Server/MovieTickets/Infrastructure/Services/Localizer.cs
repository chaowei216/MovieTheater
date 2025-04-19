using Application.Commands.Auth;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class Localizer : ILocalizer
    {
        private readonly IStringLocalizer<Localizer> _stringLocalizer;

        public Localizer(IStringLocalizer<Localizer> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public string GetString(string key)
        {
            return _stringLocalizer[key].Value;
        }
    }
}
