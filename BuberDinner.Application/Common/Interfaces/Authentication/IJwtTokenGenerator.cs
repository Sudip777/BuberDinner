namespace BuberDinner.Application.Common.Interface.Authentication;

public interface IJwtTokengenertor
{
	string GenerateToken(Guid userId, string firstName, string lastName);
}