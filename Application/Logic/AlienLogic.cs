using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep3;
using Shared.DTOs;
using Shared.Models;


namespace Application.Logic;

public class AlienLogic : IAlienLogic
{
    private readonly IALienDao AlienDao;

    public AlienLogic(IALienDao alienDao)
    {
        AlienDao = alienDao;
    }

    
    private static void ValidateData(AlienCreationDto alienToCreate)
    {
        string name = alienToCreate.Name;

        if (name.Length <= 0)
            throw new Exception("Name must be at least 1 letter");

    }

    public async Task CreateAsync(AlienCreationDto dto)
    {
        using var chanel = GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new ProofService.ProofServiceClient(chanel);
        await client.putStringAsync(new PutStringReq
        {
            Ominous = dto.Name
        });
        /*
        Alien? existing = await AlienDao.GetByNameAsync(dto.Name);
        if (existing != null)
            throw new Exception("Username already taken!");

        ValidateData(dto);
        Alien toCreate = new Alien()
        {
            Name = dto.Name
        };

        Alien created = await AlienDao.CreateAsync(toCreate);
        */
        //return created;
    }

    public Task<IEnumerable<Alien>> GetAsync(SearchAlienParametersDto searchParameters)
    {
        return AlienDao.GetAsync(searchParameters);
    }
}