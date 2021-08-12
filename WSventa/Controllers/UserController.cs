using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WSventa.Models.Request;
using WSventa.Models.Response;
using WSventa.Services;

namespace WSventa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta respuesta = new Respuesta();

            var userResponse = _userService.Auth(model);

            if (userResponse == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contraseña incorrecta";
                return BadRequest(respuesta);
            }

            respuesta.Exito = 1;
            respuesta.Data = userResponse;

            return Ok(respuesta);
        }
    }
}
