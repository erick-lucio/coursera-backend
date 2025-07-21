using Microsoft.AspNetCore.Mvc;
using WebApiCRUD.Models;
using WebApiCRUD.Validators;

namespace WebApiCRUD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static readonly List<User> users = [];

    [HttpGet]
    public IActionResult GetUsers() => Ok(users);

    [HttpPost]
    public IActionResult CreateUser(User user)
    {
        var validator = new UserValidator();
        var validationResult = validator.Validate(user);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        users.Add(user);
        return CreatedAtAction(nameof(GetUsers), user);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User updatedUser)
    {
        var validator = new UserValidator();
        var validationResult = validator.Validate(updatedUser);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        var user = users.FirstOrDefault(u => u.Id == id);
        if (user is null) return NotFound();

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user is null) return NotFound();

        users.Remove(user);
        return NoContent();
    }
}