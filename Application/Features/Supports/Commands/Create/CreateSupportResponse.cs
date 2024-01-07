﻿namespace Application.Features.Supports.Commands.Create;

public class CreateSupportResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedDate { get; set; }
}
