namespace SOVOS.IST.QRGenerator.API.Models
{
    public class QRData
    {
        [Required]
        [RegularExpression("^[0-9]{10,11}$", ErrorMessage = "Please enter valid vkntckn")]
        public string vkntckn { get; set; }
        [Required]
        [RegularExpression("^[0-9]{10,11}$", ErrorMessage = "Please enter valid avkntckn")]

        public string avkntckn { get; set; }
        [Required]
        [StringLength(36, MinimumLength = 36, ErrorMessage = "ettn must be 36 characters")]
        public string ettn { get; set; }
    }
}
