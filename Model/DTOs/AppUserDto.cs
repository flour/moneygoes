namespace moneygoes.Models.DTOs
{
    public class AppUserDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}