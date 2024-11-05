using EmenuTestApi.Core.Models;
using EmenuTestApi.Services.Services;
using EmenuTestApi.Shared.Validation;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EmenuTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] string search, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var users = await _userService.GetUsersAsync(search, page, pageSize);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            try
            {
                if (!ModelValidation.ValidateModel(user, "Name", "Designation", "Country"))
                {
                    return BadRequest("Required fields are missing or invalid.");
                }
                await _userService.AddUserAsync(user);
                return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while fetching user with ID {UserId}", user.UserId);
                 throw; 
            }
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] User user)
        {
            if (id != user.UserId) return BadRequest();

            if (!ModelValidation.ValidateModel(user, "Name", "Designation", "Country"))
            {
                return BadRequest("Required fields are missing or invalid.");
            }
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpPost("uploadImage/{userId}")]
        public async Task<IActionResult> UploadImage(int userId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound("User not found.");

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            user.ImagePath = imagePath;
            await _userService.UpdateUserAsync(user);
            return Ok(new { ImagePath = imagePath });
        }

        [HttpGet("getImage/{userId}")]
        public async Task<IActionResult> GetImage(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null || string.IsNullOrEmpty(user.ImagePath))
                return NotFound("Image not found.");

            // Assuming ImagePath is a relative path, we can return the full URL to the image
            return Redirect(user.ImagePath);
        }
    }
}

