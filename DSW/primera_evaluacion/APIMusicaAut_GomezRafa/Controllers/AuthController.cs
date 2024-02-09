namespace APIMusicaAut_GomezRafa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController (UserManager<IdentityUser> userManager,
                               RoleManager<IdentityRole> roleManager,
                               IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login (Auth model)
        {
            // Verifica si el modelo recibido es válido
            if (ModelState.IsValid)
            {
                // Busca al usuario por su nombre (correo electrónico)
                var user = await _userManager.FindByNameAsync(model.Email);

                if (user != null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, model.Password);

                    // Si la contraseña es correcta
                    if (result)
                    {
                        // Crea un token JWT y lo devuelve en la respuesta
                        var token = await CreateToken(user);
                        return Ok(new { Token = token });
                    }
                }
                else
                {
                    return NotFound("Correo no encontrado");
                }
            }

            // El modelo no es válido, devuelve un error de solicitud incorrecta
            return BadRequest("Nombre de usuario/contraseña no válidos");
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register ([FromBody] Auth model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = model.Email,
                    UserName = model.Email
                };

                // Intenta crear el usuario en la base de datos
                var result = await _userManager.CreateAsync(user, model.Password);

                // Si hay errores en la creación del usuario
                if (!result.Succeeded)
                {
                    // Agrega los errores al modelo y devuelve un error de solicitud incorrecta
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return BadRequest(ModelState);
                }

                var role = await _roleManager.FindByNameAsync("Usuario");

                // Asigna el rol al usuario recién creado
                result = await _userManager.AddToRoleAsync(user, role.Name);

                // Si hay errores al asignar el rol, devuelve un error de solicitud incorrecta
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return BadRequest(ModelState);
                }

                return Ok($"Usuario {model.Email} creado con exito.");
            }

            return BadRequest("Nombre de usuario/contraseña no válidos");
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<AuthRole>>> GetUsers ()
        {
            // Verifica si hay usuarios en la base de datos
            if (_userManager.Users == null)
            {
                return NotFound("Los usuarios no han sido encontrados.");
            }

            var users = await _userManager.Users
            .Select(a => new AuthRole
            {
                Email = a.UserName
            }).ToListAsync();

            foreach (var user in users)
            {
                var identityUser = await _userManager.FindByNameAsync(user.Email);
                var roles = await _userManager.GetRolesAsync(identityUser);
                user.Roles = roles.ToList();
            }

            return Ok(users);
        }

        private async Task<string> CreateToken (IdentityUser user)
        {
            var claims = new List<Claim>
             {
                 //Identificador único del token
                 new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 //Fecha de emisión del token
                 new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                 //Usuario portador del token
                 new(JwtRegisteredClaimNames.Sub, user.UserName)
             };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
