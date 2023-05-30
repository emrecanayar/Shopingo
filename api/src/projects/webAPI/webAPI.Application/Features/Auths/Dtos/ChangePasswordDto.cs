namespace webAPI.Application.Features.Auths.Dtos
{
    public class ChangePasswordDto
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public bool MatchNewPasswords()
        {
            return this.NewPassword.Equals(this.ConfirmPassword);
        }
    }
}
