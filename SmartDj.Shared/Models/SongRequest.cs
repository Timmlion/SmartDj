using System.ComponentModel.DataAnnotations.Schema;

namespace SmartDj.Shared.Models;

public class SongRequest
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public string SongTitle { get; set; } = String.Empty;
    public string RequestorName { get; set; } = String.Empty;
    public string DedicateeName { get; set; } = String.Empty;
    public string Message { get; set; } = String.Empty;
    public bool Played { get; set; } = false;
}