using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDj.Shared.Models;

public class FormTemplate
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public string HtmlContent { get; set; } = String.Empty;
    public bool IsActive { get; set; } = false;
    public string Name { get; set; } = String.Empty;
}