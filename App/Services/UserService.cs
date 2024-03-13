
using App.DTOs;
using App.DTOs.Validations;
using App.Services.Interfaces;
using Domain.Authentication;
using Domain.Repositories;

namespace App.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO)
    {
        if (userDTO == null)
            return ResultService.Fail<dynamic>("UserDTO is null");

        var validator = new UserDTOValidator().Validate(userDTO);

        if (!validator.IsValid)
            return ResultService.RequestError<dynamic>("Problemas de validação", validator);

        var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDTO.Email, userDTO.Password);

        if (user == null)
            return ResultService.Fail<dynamic>("Usuário não encontrado");

        var token = _tokenGenerator.GenerateToken(user);

        return ResultService.Ok<dynamic>(token);
    }
}
