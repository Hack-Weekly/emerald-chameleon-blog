using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Shared.Services.AuthServices.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string to, string body);
    }
}
