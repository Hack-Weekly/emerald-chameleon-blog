﻿using ApiServer.Data.EF.EntityRepositories;
using ApiServer.Domain.Entities.BlogPost;
using ApiServer.Domain.Entities.User;
using ApiServer.DTO.BlogPosts;
using ApiServer.DTO.Users;
using ApiServer.Shared.Services.AuthServices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace ApiServer.Controllers.Custom
{
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public UsersController(IUserService userService, IAuthenticationService authenticationService, IUserRepository userRepository, ILogger<UsersController> logger, IMediator mediator)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _logger = logger;
            _userRepository = userRepository;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<IEnumerable<GetUsersDTO>>> Get(CancellationToken token)
        {
            _logger.LogDebug("Example Debug Log Message - In GetWeatherForecast");
            var response = await _mediator.Send(new GetAllUsersQuery(), token);
            return Ok(response.ToList().MapToDTO<IEnumerable<GetUsersDTO>>());
        }


        [HttpPost(Name = "Login")]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromForm] LoginDTO loginDTO, CancellationToken cancellationToken)
        {
            if (loginDTO == null) return BadRequest("Please fill the required data");
            if (loginDTO.Password == null) return BadRequest("Password is Required");
            if (loginDTO.Username == null && loginDTO.Email == null) return BadRequest("Username or Email is Required");

            var user = await _userService.FindUser(loginDTO);
            if (user == null) return BadRequest("User with this username or email does not exist");

            var token = await _userService.LoginUser(user, loginDTO.Password, cancellationToken);

            return Ok(token);

        }

        [HttpPost(Name = "Register")]
        public async Task<ActionResult<LoginResponseDTO>> Register([FromForm] RegisterDTO registeredUser, CancellationToken cancellationToken)
        {
            if (registeredUser == null) return BadRequest("Please fill the required data");
            if (registeredUser.Username == null) return BadRequest("Username is Required");
            if (registeredUser.Email == null) return BadRequest("Email is Required");
            if (registeredUser.Password == null) return BadRequest("Password is Required");


            var token = await _userService.RegisterUser(registeredUser, cancellationToken);
            return Ok(token);
        }

        [HttpPost(Name = "SendConfirmation")]
        public async Task<IActionResult> SendConfirmation([FromForm] string email)
        {
            var user = await _userService.FindUser(new LoginDTO() { Email = email });
            if (user == null) return BadRequest("User with this email does not exist");

            await _userService.SendConfirmation(user);

            return Ok();
        }
        [HttpGet(Name = "EmailConfirmation")]
        public async Task<IActionResult> EmailConfirmation([FromQuery] string confirmationCode, [FromQuery] string userName, CancellationToken cancellationToken)
        {
            var isConfirmed = await _userService.ConfirmUser(userName, confirmationCode, cancellationToken);
            if (isConfirmed == false) return BadRequest();

            return Ok("User Confirmed");
        }

        [HttpGet(Name = "RefreshToken")]
        [Authorize]
        public async Task<ActionResult<LoginResponseDTO>> RefreshToken([FromQuery(Name = "refresh_token")] string refreshToken, CancellationToken cancellationToken)
        {
            var accessToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty) ?? "";
            if (string.IsNullOrWhiteSpace(accessToken)) { return Unauthorized(); }

            var token = await _authenticationService.ValidateRefreshToken(accessToken, refreshToken, cancellationToken);
            if (token == null) return Unauthorized();
            return Ok(token);
        }
    }
}
