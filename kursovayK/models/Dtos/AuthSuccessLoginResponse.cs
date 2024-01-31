namespace kursovayK.Models.Dtos
{
    public class AuthSuccessLoginResponse
    {
        public bool IsSucceed { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
