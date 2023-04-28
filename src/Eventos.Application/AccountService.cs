using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Eventos.Application.Contratos;
using Eventos.Application.Dtos;
using Eventos.Domain.Identity;
using Eventos.Persistence.Contratos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Application
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUserPersist _userPersist;

        public AccountService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            IUserPersist userPersist
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userPersist = userPersist;

        }
        public async Task<SignInResult> CheckUserPasswordAsync(UserUpdateDto userUpdateDto, string password)
        {
            try
            {

                var user = await _userManager.Users
                                             .SingleOrDefaultAsync(user => user.UserName == userUpdateDto.UserName.ToLower());
                //verifica a existencia do usuário, boolen se for true bloqueia o usuário
                return await _signInManager.CheckPasswordSignInAsync(user, password, false);

            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar o password {ex.Message}");
            }
        }

        public async Task<UserDto> CreateAccountAsync(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var result = await _userManager.CreateAsync(user, userDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _mapper.Map<UserDto>(user);
                    return userToReturn;
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar criar usuário {ex.Message}");
            }
        }

        public async Task<UserUpdateDto> GetUserByUsernameAsync(string username)
        {
            try
            {

                var user = await _userPersist.GetUserByUsernameAsync(username);
                if (user == null) return null;

                var userUpdateDto = _mapper.Map<UserUpdateDto>(user);
                return userUpdateDto;

            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar recuperar usuário por username {ex.Message}");
            }
        }

        public async Task<UserUpdateDto> UpdateAccount(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await _userPersist.GetUserByUsernameAsync(userUpdateDto.UserName);
                if (user == null) return null;

                _mapper.Map(userUpdateDto, user);

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, userUpdateDto.Password);

                _userPersist.Update<User>(user);

                if (await _userPersist.SaveChangesAsync())
                {
                    var userRetorno = await _userPersist.GetUserByUsernameAsync(user.UserName);
                    return _mapper.Map<UserUpdateDto>(userRetorno);
                }
                return null;

            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar atualizar {ex.Message}");
            }
        }

        public async Task<bool> UserExists(string username)
        {
            try
            {
                return await _userManager.Users.AnyAsync(user => user.UserName == username.ToLower());
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro ao tentar verificar se usuário existe{ex.Message}");
            }
        }
    }
}