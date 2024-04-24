using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDJ.Server;

public class FormTemplate
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public string HtmlContent { get; set; } = String.Empty;
    public bool IsActive { get; set; } = false;
}