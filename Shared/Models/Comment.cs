﻿namespace Shared.Models;

public class Comment
{
    public string Text { get; set; }
    public string FarmerId { get; set; }
    public string CustomerId { get; set; }
    public int OrderId { get; set; }
    public string Username { get; set; }
    public int CommentId { get; set; }
}