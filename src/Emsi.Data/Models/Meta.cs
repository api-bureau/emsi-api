using System.ComponentModel.DataAnnotations;

namespace Emsi.Data.Models
{
    public class Meta
    {
        [Key]
        public string LatestVersion { get; set; } = null!;
    }
}
