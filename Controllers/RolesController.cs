using backendnet.Data;
using backendnet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace backendnet.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Administrador")]
public class RolesController(IdentityContext context) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRolDTO>>> GetRoles(){
        var roles = new List<UserRolDTO>();
        foreach(var rol in await context.Roles.AsNoTracking().ToListAsync())
        {
            roles.Add(new UserRolDTO
            {
                Id = rol.Id,
                Nombre = rol.Name!
            });
        }
        return roles;
    }
}