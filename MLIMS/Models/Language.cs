using System.ComponentModel.DataAnnotations;

namespace MLIMS.Models
{
    public class Language
    {
        [Key]
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}