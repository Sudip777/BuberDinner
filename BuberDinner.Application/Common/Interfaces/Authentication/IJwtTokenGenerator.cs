namespace BuberDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenertor
{
	string GenerateToken(Guid userId, string firstName, string lastName);
}