namespace Core.Mailing
{
    public class ToEmail
    {
        public string Email { get; set; }
        public string FullName { get; set; }

        public ToEmail()
        {
        }

        public ToEmail(string email, string fullName) : this()
        {
            Email = email;
            FullName = fullName;
        }
    }
}
