using Application.DaoInterfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Sep;
using Shared.DTOs;
using Shared.DTOs.Create;
using Shared.DTOs.Search;
using Shared.Models;

namespace gRPCData.DAOs;

public class ReviewDao: IReviewDao
{
    public async Task<string> CreateAsync(ReviewCreateDto alien)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreatePostReviewRequest(DTOFactory.toDtoReview(alien));
        try
        {
            var response = client.postReview(request);
            string createdReview = response.Resp;
            return createdReview;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }

   
    public async Task<IEnumerable<Review>> GetAllAsync(string farmer)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.CreateGetAllReviewsByFarmerRequest(farmer);
        try
        {
            var response = await client.getAllReviewsByFarmerAsync(request);
            List<Review> reviews = new List<Review>();
            foreach (var item in response.AllReviews)
            {
                reviews.Add(DTOFactory.toReview(item));
            }
            return reviews;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
        
    }

    public async Task<string> PostComment(CommentCreateDto comment)
    {
        using var chanel= GrpcChannel.ForAddress("http://localhost:1337",new GrpcChannelOptions
        {
            Credentials = ChannelCredentials.Insecure
            
             
        });
        var client = new SepService.SepServiceClient(chanel);
        var request = DTOFactory.PostCommentRequest(DTOFactory.toDtoComment(comment));
        try
        {
            var response = client.postComment(request);
            if (response.Resp.Contains("Error"))
            {
                throw new Exception(response.Resp);
            }
            string created = response.Resp;
            return created;
        }
        catch (RpcException e)
        {
            Console.WriteLine($"gRPC Error: {e.Status}");
            throw;
        }
    }
}