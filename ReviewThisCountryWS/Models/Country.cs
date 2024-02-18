using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReviewThisCountryWS.Models
{
    [Table("Countries", Schema = "CountrySchema")]
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string CountryName { get; set; }
        public Decimal AverageRating { get; set; }
        public int OneStarCount { get; set; }
        public int TwoStarsCount { get; set; }
        public int ThreeStarsCount { get; set; }
        public int FourStarsCount { get; set; }
        public int FiveStarsCount { get; set; }
    }
}