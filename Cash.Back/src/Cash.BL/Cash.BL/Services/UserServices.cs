using System.Security.Claims;
using Cash.BE.Dtos;
using Cash.BE.Extensions;
using Cash.BE.Helpers;
using Cash.BE.Models;
using Cash.BE.Request;
using Cash.BL.Attributes;
using Cash.BL.Interfaces;
using Cash.DAC.Interfaces;
using Cash.Exceptions.Exceptions;
using Cash.Exceptions.Helpers;
using Cash.Mapper.Mappers;
using Microsoft.AspNetCore.Http;

namespace Cash.BL.Services;

[Service]
public class UserServices(IRepository<User> userRepository, IHttpContextServices httpContextServices) : IUserServices
{
    private readonly IRepository<User> _userRepository = userRepository;
    private readonly IHttpContextServices _httpContextServices = httpContextServices;

    public async Task<ApiResponse<bool>> CreateAsync(UserCreateRequest userCreateRequest)
    {
        var response = new ApiResponse<bool>();
        var claims = _httpContextServices.GetClaims();

        var user = userCreateRequest.UserCreateMapper();
        user.CreatedBy = Convert.ToInt32(claims?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        user.StatusId = StatusHelper.WaitApproval;
        user.Password = user.Password!.HashPassword();
        await _userRepository.AddAsync(user);
        var inserted = await _userRepository.SaveChangesAsync();
        inserted.InvalidDml();

        response.SetReponse(StatusCode.Created, true);
        
        return response;
    }

    public async Task<ApiResponse<bool>> ApprovalAsync(UserApprovalRequest userApprovalRequest)
    {
        var response = new ApiResponse<bool>();
        var claims = _httpContextServices.GetClaims();
        
        var user = await _userRepository.FindByIdAsync(userApprovalRequest.Id);
        
        if (user is null) throw new NotFoundException(MessageExceptions.NotFound);
        
        user.StatusId = userApprovalRequest.StatusId;   
        user.ApprovalDate = DateTime.Now;
        user.UserApproval = Convert.ToInt32(claims!.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        
        _userRepository.Update(user);
        var updated = await _userRepository.SaveChangesAsync();
        updated.InvalidDml();

        response.Data = true;
        response.SetReponse(StatusCode.NoContent, true);
        
        return response;
    }
}