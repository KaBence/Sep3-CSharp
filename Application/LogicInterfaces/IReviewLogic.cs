﻿using Shared.DTOs.Create;
using Shared.Models;

namespace Application.LogicInterfaces;

public interface IReviewLogic
{
    Task<string> CreateAsync(ReviewCreateDto dto);
    Task<IEnumerable<Review>> GetAllAsync(string farmer);
    Task<string> CreateCommentAsync(CommentCreateDto dto);
}