using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.DTOs;
using Shared.Models;

namespace HttpClients.ClientInterfaces
{
    public interface IStringService
    {
        Task CreateAsync(AlienCreationDto dto);
    
        Task<ICollection<Alien>> GetAsync();
    }
}