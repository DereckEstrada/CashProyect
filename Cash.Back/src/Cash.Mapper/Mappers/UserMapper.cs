using Cash.BE.Models;
using Cash.BE.Request;
using Cash.BE.UpdateRequest;

namespace Cash.Mapper.Mappers;

public static  class UserMapper
{
    public static User UserCreateMapper(this UserCreateRequest userCreateRequest)
    {
        return new User()
        {
            UserName = userCreateRequest.UserName,
            Email = userCreateRequest.Email,
            RolId = userCreateRequest.RolId,
            Password = userCreateRequest.Password, 
        };
    }

    public static List<User> UserCreateListMapper(List<UserCreateRequest> usersCreateRequest)
    {
        var users = new List<User>();
        usersCreateRequest.ForEach(createRequest =>
        {
            users.Add(UserCreateMapper(createRequest));
        });
        return users;
    }
    public static User UserUpdateMapper(UserUpdateRequest userUpdateRequest)
    {
        return new User()
        {
            Id = userUpdateRequest.Id,
            UserName = userUpdateRequest.UserName,
            Email = userUpdateRequest.Email,
            Password = userUpdateRequest.Password,
            RolId = userUpdateRequest.RolId,
            StatusId = userUpdateRequest.StatusId,
        };
    }

    public static List<User> UserUpdateListMapper(List<UserUpdateRequest> usersUpdateRequest)
    {
        var users = new List<User>();
        usersUpdateRequest.ForEach(createRequest =>
        {
            users.Add(UserUpdateMapper(createRequest));
        });
        return users;
    }
}