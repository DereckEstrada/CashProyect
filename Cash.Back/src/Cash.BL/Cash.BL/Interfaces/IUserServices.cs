using Cash.BE.Dtos;
using Cash.BE.Models;
using Cash.BE.Request;
using Cash.BE.UpdateRequest;

namespace Cash.BL.Interfaces;

public interface IUserServices
{
    Task<ApiResponse<bool>> CreateAsync(UserCreateRequest userCreateRequest);
    Task<ApiResponse<bool>> ApprovalAsync(UserApprovalRequest userApprovalRequest);
    //Task<ApiResponse<bool>> DeleteAsync(UserCreateRequest userCreateRequest);
}