using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IAlienLogic
{
    Task CreateAsync(AlienCreationDto dto);
    Task<IEnumerable<Alien>> GetAsync(SearchAlienParametersDto searchParameters);
}