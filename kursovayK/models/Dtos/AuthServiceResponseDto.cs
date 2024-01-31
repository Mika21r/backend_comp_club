namespace kursovayK.Models.Dtos 
{ 
    public class AuthServiceResponseDto
    {
        public bool IsSucceed { get; set; }
        public string? Message { get; set; }

        public string? UserEmail { get; set; }
        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }

        public IList<string>? Roles { get; set; }
    }
}
