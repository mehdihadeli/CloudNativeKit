using CloudNativeKit.Core.Exception;

namespace CloudNativeKit.Core.Domain.Exceptions;

public class InvalidDateException : BadRequestException
{
    public DateTime Date { get; }

    public InvalidDateException(DateTime date)
        : base($"Date: '{date}' is invalid.")
    {
        Date = date;
    }
}
