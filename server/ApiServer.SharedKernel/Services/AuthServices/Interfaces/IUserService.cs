using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServer.Shared.Services.AuthServices.Interfaces
{
    public interface IUserService
    {
        Task<bool> ConfirmUser(string userName, string confirmationCode, CancellationToken cancellationToken);
        Task<User> FindUser(LoginDTO loginModel);
        Task<LoginResponseDTO> LoginUser(User registeredUser, string providedPassword, CancellationToken cancellationToken);
        Task<LoginResponseDTO> RegisterUser(RegisterDTO registerModel, CancellationToken cancellationToken);
        Task SendConfirmation(User registeredUser);
    }
}
