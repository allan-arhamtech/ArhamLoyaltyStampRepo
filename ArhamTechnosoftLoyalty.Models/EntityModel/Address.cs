using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArhamTechnosoftLoyalty.Models.EntityModel
{
    public partial class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
