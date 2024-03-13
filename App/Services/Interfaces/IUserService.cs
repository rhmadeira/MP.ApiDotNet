using App.DTOs;
using Domain.Entities;

namespace App.Services.Interfaces;

public interface IUserService
{
    Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO);
}
