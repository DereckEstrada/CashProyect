using Cash.BE.Helpers;
using Npgsql;

namespace Cash.BE.Extensions;

public static class InvalidDmlExtension
{
    public static void InvalidDml(this int dmlOperation)
    {
        if(dmlOperation <=0) throw new OperationCanceledException(ErrorMessage.FailedOperation);
    }
}