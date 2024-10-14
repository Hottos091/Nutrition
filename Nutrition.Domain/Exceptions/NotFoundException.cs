namespace Nutrition.Domain.Exceptions;

public class NotFoundException(string resourceType, string resourceId)
    : Exception($"{resourceType} with id {resourceId} cannot be found; it probably doesn't exist.")
{
}
