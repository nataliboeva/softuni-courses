using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static Common.EntityValidationConstants.User;
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(UserUsernameMaxLength)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(UserPasswordMaxLength)]
        public string Password { get; set; } = null!;
        [Required]
        [MaxLength(UserEmailMaxLength)]
        public string Email { get; set; } = null!;
        public decimal Balance { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
            = new HashSet<Bet>();
    }
}
