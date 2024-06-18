using backendnet.Data;
using backendnet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Controllers;

[Route("api/[controller]")]
[ApiController]

public class UsuariosController(IdentityContext context, UserManager<CustomIdentityUser> UserManager) : Controller
{
    //GET: api/usuarios
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomIdentityUserDTO>>> GetUsuarios()
    {
        var usuarios = new List<CustomIdentityUserDTO>();

        foreach (var usuario in await context.Users.AsNoTracking().ToListAsync())
        {
            usuarios.Add(new CustomIdentityUserDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email!,
                Rol = GetUserRol(usuario)
            });
        }
        return usuarios;
    }

    //GET: api/usuarios/email
    [HttpGet("{email}")]
    public async Task<ActionResult<CustomIdentityUserDTO>> GetUsuario(string email)
    {
        var usuario = await UserManager.FindByEmailAsync(email);

        if(usuario == null) return NotFound();

        return new CustomIdentityUserDTO
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Email = usuario.Email!,
            Rol = GetUserRol(usuario)
        };
    }

    //POST: api/usuarios
    [HttpPost]
    public async Task<ActionResult<CustomIdentityUserDTO>> PostUsuario(CustomIdentityUserPwdDTO usuarioDTO)
    {
        var usuarioToCreate = new CustomIdentityUser
        {
            UserName = usuarioDTO.Email,
            Email = usuarioDTO.Email,
            NormalizedEmail = usuarioDTO.Email.ToUpper(),
            Nombre = usuarioDTO.Nombre,
            NormalizedUserName = usuarioDTO.Email.ToUpper()
        };

        //Agrega al usuario
        IdentityResult result = await UserManager.CreateAsync(usuarioToCreate, usuarioDTO.Password);
        if(!result.Succeeded) return BadRequest(new { mensaje = "El usuario no se ha podido crear." });

        //Lo agrega al Rol deseado
        result = await UserManager.AddToRoleAsync(usuarioToCreate, usuarioDTO.Rol);

        //Regresa el usuario creado
        var usuarioViewModel = new CustomIdentityUserDTO
        {
            Id = usuarioToCreate.Id,
            Nombre = usuarioDTO.Nombre,
            Email = usuarioDTO.Email,
            Rol = usuarioDTO.Rol
        };

        return CreatedAtAction(nameof(GetUsuario), new { email = usuarioDTO.Email }, usuarioViewModel);
    }

    //PUT: api/usuarios/email
    [HttpPut("{email}")]
    public async Task<IActionResult> PutUsuario(string email, CustomIdentityUserDTO usuarioDTO)
    {
        if(email != usuarioDTO.Email) return BadRequest();

        var usuario = await UserManager.FindByEmailAsync(email);
        if(usuario == null) return NotFound();

        //Verifica que exista el rol recibido
        if(await context.Roles.Where(r => r.Name == usuarioDTO.Rol).FirstOrDefaultAsync() == null) return NotFound();

        //Actualiza los datos
        usuario.Nombre = usuarioDTO.Nombre;
        usuario.NormalizedUserName = usuarioDTO.Email.ToUpper();
        IdentityResult result = await UserManager.UpdateAsync(usuario);
        if(!result.Succeeded) return BadRequest();

        //Actualiza el rol seleccionado
        foreach(var rol in await context.Roles.ToListAsync())
            await UserManager.RemoveFromRoleAsync(usuario, rol.Name!);
        await UserManager.AddToRoleAsync(usuario, usuarioDTO.Rol);

        return NoContent();
    }

    //DELETE: api/usuarios/email
    [HttpDelete("{email}")]
    public async Task<IActionResult> DeleteUsuario(string email)
    {
        var usuario = await UserManager.FindByEmailAsync(email);
        if(usuario == null) return NotFound();

        if(usuario.Protegido) return StatusCode(StatusCodes.Status403Forbidden);

        IdentityResult result = await UserManager.DeleteAsync(usuario);
        if(!result.Succeeded) return BadRequest();

        return NoContent();
    }

    private string GetUserRol(CustomIdentityUser usuario)
    {
        var roles = UserManager.GetRolesAsync(usuario).Result;
        return roles.Fisrt();
    }
}