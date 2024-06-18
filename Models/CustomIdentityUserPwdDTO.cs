namespace backendnet.Models;

public class CustomIdentityUserPwdDTO
{
    public string? Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Nombre { get; set; }
    public required string Rol { get; set; }
}