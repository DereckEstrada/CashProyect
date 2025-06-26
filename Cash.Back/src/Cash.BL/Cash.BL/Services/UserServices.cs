using Cash.BE.Dtos;
using Cash.BE.Extensions;
using Cash.BE.Helpers;
using Cash.BE.Models;
using Cash.BE.Request;
using Cash.BL.Attributes;
using Cash.BL.Interfaces;
using Cash.DAC.Interfaces;
using Cash.Mapper.Mappers;

namespace Cash.BL.Services;
[Service]
public class UserServices(IRepository<User> userRepository, CashDbContext context) : IUserServices
{
    private readonly IRepository<User> _userRepository = userRepository;
    public async Task<ApiResponse<bool>> CreateUserAsync(UserCreateRequest userCreateRequest)
    {
        var response = new ApiResponse<bool>();
        try
        {
            var user = userCreateRequest.UserCreateMapper();
            await _userRepository.AddAsync(user);
            var inserted = await _userRepository.SaveChangesAsync();
            inserted.InvalidDml();
            
            response.Data = true;
            response.SetStatusCodeAndMessage(StatusCode.Created);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return response;
    }
}