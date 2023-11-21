using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs;

namespace gRPCData.DAOs;

public class LoginDao:ILoginDao
{
    public async Task<LoginSuccessDto> GetSuccess(LoginDto dto)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
            
             
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateLoginRequest(DTOFactory.toDtoLogin(dto));
        try
        {
            var response = client.login(request);
            LoginSuccessDto succ = new LoginSuccessDto
            {
                PhoneNumber = response.PhoneNumber,
                Identity = response.InstanceOf
            };
            return succ;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }
}