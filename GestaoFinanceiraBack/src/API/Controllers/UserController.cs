using Application.InputModels.UserInputModels;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(IUsersServices usersServices) : ControllerBase
    {
        private readonly IUsersServices _usersServices = usersServices;

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>User collection</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _usersServices.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _usersServices.GetByIdAsync(id);
            return Ok(user);
        }

        /// <summary>
        /// Get the current user
        /// </summary>
        /// <returns>User</returns>
        /// <response code="200">Success</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>Only the current user can get itself</remarks>
        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            var user = await _usersServices.GetMeAsync(User);
            return Ok(user);
        }

        /// <summary>
        /// Check if the email is available
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>True if the email is available</returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmail([FromQuery] string email)
        {
            var isAvailable = await _usersServices.CheckEmailAsync(email);
            return Ok(isAvailable);
        }

        /// <summary>
        /// Check if the phone number is available
        /// </summary>
        /// <param name="phone">Phone number</param>
        /// <returns>True if the phone number is available</returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("check-phone")]
        public async Task<IActionResult> CheckPhone([FromQuery] string phone)
        {
            var isAvailable = await _usersServices.CheckPhoneAsync(phone);
            return Ok(isAvailable);
        }

        /// <summary>
        /// Check if the password reset token is valid
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="token">Token</param>
        /// <returns>True if the token is valid</returns>
        /// <response code="200">Success</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet("check-password-reset-token")]
        public async Task<IActionResult> CheckPasswordResetToken([FromQuery] string key, [FromQuery] string token)
        {
            var isValid = await _usersServices.CheckPasswordResetTokenAsync(key, token);
            return Ok(isValid);
        }

        /// <summary>
        /// Register me
        /// </summary>
        /// <param name="inputModel">User input model</param>
        /// <returns>Token</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterMeInputModel inputModel)
        {
            var token = await _usersServices.RegisterMeAsync(inputModel);
            return Ok(token);
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="inputModel">User input model</param>
        /// <returns>User</returns>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="409">Conflict</response>
        /// <response code="500">Internal Server Error</response>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterUserInputModel inputModel)
        {
            var user = await _usersServices.RegisterAsync(inputModel);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="inputModel">User input model</param>
        /// <returns>User</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>Only admins can update users</remarks>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserInputModel inputModel)
        {
            var user = await _usersServices.UpdateAsync(id, inputModel);
            return Ok(user);
        }

        /// <summary>
        /// Update the current user
        /// </summary>
        /// <param name="inputModel">User input model</param>
        /// <returns>User</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>Only the current user can update itself</remarks>
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutMe([FromBody] UpdateMeInputModel inputModel)
        {
            var user = await _usersServices.UpdateMeAsync(inputModel, User);
            return Ok(user);
        }

        /// <summary>
        /// Change the user password
        /// </summary>
        /// <param name="inputModel">Change password input model</param>
        /// <returns>No content</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPatch("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordInputModel inputModel)
        {
            await _usersServices.ChangePasswordAsync(inputModel);
            return NoContent();
        }

        /// <summary>
        /// Change the user email
        /// </summary>
        /// <param name="inputModel">Change email input model</param>
        /// <returns>User</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>Only the current user can change its email</remarks>
        [Authorize]
        [HttpPatch("change-email")]
        public async Task<IActionResult> ChangeEmail([FromBody] ChangeUserEmailInputModel inputModel)
        {
            var user = await _usersServices.ChangeEmailAsync(inputModel, User);
            return Ok(user);
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>No content</returns>
        /// <response code="204">No Content</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>Only admins can delete users</remarks>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _usersServices.DeleteAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Send an email change token
        /// </summary>
        /// <param name="inputModel">Send email change token input model</param>
        /// <returns>No content</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        /// <remarks>Only the current user can send an email change token</remarks>
        [Authorize]
        [HttpPost("send-email-change-token")]
        public async Task<IActionResult> SendEmailChangeToken([FromBody] SendEmailChangeTokenInputModel inputModel)
        {
            await _usersServices.SendEmailChangeTokenAsync(inputModel, User);
            return NoContent();
        }

        /// <summary>
        /// Send a password reset token
        /// </summary>
        /// <param name="inputModel">Send password change token input model</param>
        /// <returns>No content</returns>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("send-password-reset-token")]
        public async Task<IActionResult> SendPasswordResetToken([FromBody] SendPasswordChangeTokenInputModel inputModel)
        {
            await _usersServices.SendPasswordResetTokenAsync(inputModel);
            return NoContent();
        }

        /// <summary>
        /// Authenticate a user
        /// </summary>
        /// <param name="inputModel">Authenticate user input model</param>
        /// <returns>Token</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserInputModel inputModel)
        {
            var token = await _usersServices.AuthenticateAsync(inputModel);
            return Ok(token);
        }

        /// <summary>
        /// Authenticate a user with Google
        /// </summary>
        /// <param name="inputModel">Authenticate user with Google input model</param>
        /// <returns>Token</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server Error</response>
        [HttpPost("authenticate-with-google")]
        public async Task<IActionResult> AuthenticateWithGoogle([FromBody] AuthenticateUserWithGoogleInputModel inputModel)
        {
            var token = await _usersServices.AuthenticateWithGoogleAsync(inputModel);
            return Ok(token);
        }
    }
}