using Application.DaoInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace FileData.DAOs;

public class AlienFileDao : IALienDao
{
    private readonly FileContext context;

    public AlienFileDao(FileContext context)
    {
        this.context = context;
    }

    public Task<Alien> CreateAsync(Alien alien)
    {
        int alienId = 1;
        if (context.Aliens.Any())
        {
            alienId = context.Aliens.Max(u => u.Id);
            alienId++;
        }

        alien.Id = alienId;

        context.Aliens.Add(alien);
        context.SaveChanges();

        return Task.FromResult(alien);
    }

    public Task<Alien?> GetByNameAsync(string name)
    {
        Alien? existing = context.Aliens.FirstOrDefault(u =>
            u.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }

    public Task<IEnumerable<Alien>> GetAsync(SearchAlienParametersDto searchParameters)
    {
        IEnumerable<Alien> aliens = context.Aliens.AsEnumerable();
        if (searchParameters.UsernameContains != null)
        {
            aliens = context.Aliens.Where(u => u.Name.Contains(searchParameters.UsernameContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(aliens);
    }
}