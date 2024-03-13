using Domain.Entities;

namespace Domain.Authentication;

public interface ITokenGenerator
{
    dynamic GenerateToken(User user);
}
