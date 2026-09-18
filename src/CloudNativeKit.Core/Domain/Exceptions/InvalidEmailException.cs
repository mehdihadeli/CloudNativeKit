using CloudNativeKit.Core.Exception;

namespace CloudNativeKit.Core.Domain.Exceptions;

public class InvalidEmailException : BadRequestException
{
    public string Email { get; }

    public InvalidEmailException(string email)
        : base($"Email: '{email}' is invalid.")
    {
        Email = email;
    }
}
