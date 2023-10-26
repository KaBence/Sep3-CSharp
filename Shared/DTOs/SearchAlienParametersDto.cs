namespace Shared.DTOs;

public class SearchAlienParametersDto
{
    public string? UsernameContains { get;  }

    public SearchAlienParametersDto(string? usernameContains)
    {
        UsernameContains = usernameContains;
    }
}