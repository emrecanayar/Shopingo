using Core.Domain.Entities.Base;
using static Core.Domain.ComplexTypes.Enums;

namespace Core.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? UserName { get; set; }
        public string? RegistrationNumber { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }
        public CultureType CultureType { get; set; }
        public Guid CountryId { get; set; }
        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<PasswordResetHistory> PasswordResetHistories { get; set; }
        public virtual ICollection<PasswordResetToken> PasswordResetTokens { get; set; }
        public virtual ICollection<ContactUsForm> ContactUsForms { get; set; }
        public Country Country { get; set; }
        public User()
        {
            UserOperationClaims = new HashSet<UserOperationClaim>();
            RefreshTokens = new HashSet<RefreshToken>();
            PasswordResetHistories = new HashSet<PasswordResetHistory>();
            PasswordResetTokens = new HashSet<PasswordResetToken>();
            ContactUsForms = new HashSet<ContactUsForm>();
        }

        public User(Guid id, string firstName, string lastName, string email, string userName, string registrationNumber, byte[] passwordSalt, byte[] passwordHash, AuthenticatorType authenticatorType, CultureType cultureType, Guid countryId) : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            RegistrationNumber = registrationNumber;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            AuthenticatorType = authenticatorType;
            CultureType = cultureType;
            CountryId = countryId;
        }
    }
}
