namespace CloudNativeKit.Abstractions.Web.Problem;

public interface IProblemDetailMapper
{
    int GetMappedStatusCodes(Exception? exception);
}
