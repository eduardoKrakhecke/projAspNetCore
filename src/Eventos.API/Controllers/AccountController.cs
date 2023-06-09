using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Eventos.Application.Contratos;
using Microsoft.AspNetCore.Http;
using Eventos.Application.Dtos;
using System.Security.Claims;
using Eventos.API.Extensions;

namespace Eventos.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService
        )
        {
            _accountService = accountService;
            _tokenService = tokenService;

        }
        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {

            try
            {
                var userName = User.GetUserName();
                var user = await _accountService.GetUserByUsernameAsync(userName);
                return Ok(user);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar usuário. Erro: {ex.Message}");
            }

        }


        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto userDto)
        {

            try
            {
                if (await _accountService.UserExists(userDto.Username))
                {
                    return BadRequest("Usuário já existe");
                }

                 var user = await _accountService.CreateAccountAsync(userDto);
                if (user != null)
                {
                    return Ok( new {
                        userName = user.UserName,
                        primeiroNome = user.PrimeiroNome,
                        token = _tokenService.CreateToken(user).Result
                    });
                }

                return BadRequest("Usuário não criado, tente novamente mais tarde");
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar registrar usuário. Erro: {ex.Message}");
            }

        }



        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLogin)
        {

            try
            {
                var user = await _accountService.GetUserByUsernameAsync(userLogin.Username);
                if(user == null) return Unauthorized("Usuário ou senha inválidos");

                 var result = await _accountService.CheckUserPasswordAsync(user, userLogin.Password);
                 if (!result.Succeeded) return Unauthorized();

                return Ok(
                    new {
                        userName = user.UserName,
                        primeiroNome = user.PrimeiroNome,
                        token = _tokenService.CreateToken(user).Result
                    }
                );
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar realizar login usuário. Erro: {ex.Message}");
            }

        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {

            try
            {
                var user = await _accountService.GetUserByUsernameAsync(User.GetUserName());
                if(user == null) return Unauthorized("Usuário inválido");

                var userReturn = await _accountService.UpdateAccount(userUpdateDto);
                if (userReturn == null)
                {
                    return NoContent();
                }

                return Ok(userReturn);
            }
            catch (System.Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar atualizar usuário. Erro: {ex.Message}");
            }

        }
    }
}