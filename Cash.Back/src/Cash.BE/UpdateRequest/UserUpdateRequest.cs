using System.ComponentModel.DataAnnotations;
using Cash.BE.Helpers;
using Cash.BE.Request;

namespace Cash.BE.UpdateRequest;

public class UserUpdateRequest: UserCreateRequest
{
    public  int Id { get; set; }
    public  int StatusId { get; set; }
}