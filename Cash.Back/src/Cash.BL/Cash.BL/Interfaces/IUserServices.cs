using Cash.BE.Dtos;
using Cash.BE.Models;
using Cash.BE.Request;

namespace Cash.BL.Interfaces;

public interface IUserServices
{
    Task<ApiResponse<bool>> CreateUserAsync(UserCreateRequest userCreateRequest);
}