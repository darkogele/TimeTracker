namespace TimeTracker.Shared.Models.Login;

public record struct LoginResponse(bool IsSuccessful, string? Errors = null, string? Token = null);