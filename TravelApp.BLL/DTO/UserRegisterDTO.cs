namespace TravelApp.BLL.DTO
{
    public class UserRegisterDTO
    {
        public long userId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
