namespace SecureVigil.DAL
{
    public class UserData
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }
    
        public bool IsAdmin { get; set; }
    }
}
