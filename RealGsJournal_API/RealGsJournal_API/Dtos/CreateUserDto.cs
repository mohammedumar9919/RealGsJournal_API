namespace RealGsJournal_API.Dtos
{
    public class CreateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; // raw password (will be hashed)
        public string Role { get; set; } = string.Empty; // Admin or Viewer
    }
}

