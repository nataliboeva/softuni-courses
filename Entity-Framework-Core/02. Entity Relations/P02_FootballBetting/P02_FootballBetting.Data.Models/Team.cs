using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Team;
    public class Team
    {
        
        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(TeamNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(TeamLogoUrlMaxLength)]
        public string LogoUrl { get; set; }

        [Required]
        [MaxLength(TeamNameMaxLength)]
        public string Inititals { get; set; } = null!;
        public string Budget { get; set; }
        public string PrimaryKitColorId { get; set; }
        public string SecondaryKitColorId { get; set;}
    }
}
