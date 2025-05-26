using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;

[Authorize]
public class UsersController(DataContext context): BaseApiController
{
[AllowAnonymous]
[HttpGet]
public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
{
var users = await context.Users.ToListAsync();

return users;
}

[AllowAnonymous]
[HttpGet("{id:int}")]// /api/user/3
public  async Task<ActionResult<AppUser>>GetUser(int id)
{
var user = await context.Users.FindAsync(id);
if (user == null) return NotFound();

return user;
}


}