using Shared.DTOs;
using Shared.Models;

namespace Application.DaoInterfaces;

public interface IALienDao
{
    Task<Alien> CreateAsync(Alien alien);
    Task<Alien?> GetByNameAsync(string name);
    Task<IEnumerable<Alien>> GetAsync(SearchAlienParametersDto searchParameters);
}