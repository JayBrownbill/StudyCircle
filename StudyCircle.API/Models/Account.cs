﻿namespace StudyCircle.API.Models;

public class Account
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }

}