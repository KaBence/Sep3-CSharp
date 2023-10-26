using Shared.Models;

namespace Shared.DTOs;

public class AlienCreationDto
{
    
    public string Name { get; }

    public AlienCreationDto(string name)
    {
        Name = name;
    }
}