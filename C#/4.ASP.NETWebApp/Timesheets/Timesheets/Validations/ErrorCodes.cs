using System;
using Microsoft.Extensions.Configuration;

namespace Timesheets.Validations
{
    public class ErrorCodes : IErrorCodes
    {
        private readonly IConfiguration _configuration;

        public ErrorCodes(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public string GetMessage(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            return _configuration.GetSection("ErrorCodes")[key];
        }
    }
}