using Shared.DTOs;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IAlienLogic
{
    public Task<Alien> CreateAsync(AlienCreationDto dto);
    public Task<IEnumerable<Alien>> GetAsync(SearchAlienParametersDto searchParameters);
}