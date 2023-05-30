using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class PasswordResetToken : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Email { get; set; }
        public string ClientURI { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public bool IsUsed { get; set; }

        public PasswordResetToken()
        {

        }

        public PasswordResetToken(Guid id, Guid userId, User user, string email, string clientURI, string token, DateTime tokenExpireDate, bool isUsed) : this()
        {
            UserId = userId;
            User = user;
            Email = email;
            ClientURI = clientURI;
            Token = token;
            TokenExpireDate = tokenExpireDate;
            IsUsed = isUsed;
        }
    }
}
