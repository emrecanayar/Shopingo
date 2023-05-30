using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class PasswordResetHistory : Entity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string OldPassword { get; set; }
        public string OldPasswordSalt { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordSalt { get; set; }

        public PasswordResetHistory()
        {

        }

        public PasswordResetHistory(Guid id, Guid userId, User user, string oldPassword, string oldPasswordSalt, string newPassword, string newPasswordSalt) : this()
        {
            Id = id;
            UserId = userId;
            User = user;
            OldPassword = oldPassword;
            OldPasswordSalt = oldPasswordSalt;
            NewPassword = newPassword;
            NewPasswordSalt = newPasswordSalt;
        }
    }
}
