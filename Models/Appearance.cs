namespace CharaLog.Models;

public class Appearance
{
    public Guid AppearanceId { get; set; } = Guid.NewGuid();
    public Guid CharacterId { get; set; }
    public int EpisodeNo { get; set; }
    public AppearanceType AppearType { get; set; }
    public string? Note { get; set; }
}