using System.ComponentModel.DataAnnotations;
using Cash.BE.Helpers;

namespace Cash.BE.Request;

public class UserApprovalRequest
{
    [Required (ErrorMessage = ErrorMessage.RequiredId)]
    public  int Id { get; set; }
    [Required (ErrorMessage = ErrorMessage.RequiredStatus)]
    public required int StatusId { get; set; }
    
}