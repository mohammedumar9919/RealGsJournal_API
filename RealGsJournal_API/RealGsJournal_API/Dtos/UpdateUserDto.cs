namespace RealGsJournal_API.Dtos
{
    public class UpdateUserDto
    {
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}

