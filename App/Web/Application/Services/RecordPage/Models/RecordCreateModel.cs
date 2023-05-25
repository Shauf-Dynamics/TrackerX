using System.ComponentModel.DataAnnotations;

namespace Web.Application.Endpoints.RecordPage.Models
{
    public class RecordCreateModel
    {
        [Required]
        public DateTime? DateTimeCreated { get; set; }
    }
}
