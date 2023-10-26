using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface IStringService
    {
        Task CreateAsync(string dto);
    
        Task<ICollection<string>> GetAsync();
    }
}