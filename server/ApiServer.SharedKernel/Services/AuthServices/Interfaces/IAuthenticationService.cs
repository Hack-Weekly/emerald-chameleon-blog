namespace ApiServer.Shared.Services.AuthServices.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDTO> GenerateJWToken(User registeredUser, CancellationToken cancellationToken, bool refreshExpired = false);
        Task<LoginResponseDTO> ValidateRefreshToken(string accessToken, string refreshToken, CancellationToken cancellationToken);

    }
}
