using System.ComponentModel.DataAnnotations;

namespace GoatPortfolio.Models
{
    public class UsersApiKey
    {
        public int Id { get; set; }

        public string User { get; set; }
        
        [DataType(DataType.Text)]
        [Required (ErrorMessage = "Please enter a valid Alpha Venture API Key")]
        [MinLength(10)]
        [MaxLength(30)]
        public string ApiKey { get; set; }

        [DataType(DataType.Text)]
        [Required (ErrorMessage = "Please enter a valid Forex API Key")]
        [MinLength(30)]
        [MaxLength(40)]
        public string ForexKey { get; set; }
    }
}