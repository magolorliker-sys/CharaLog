namespace CharaLog.Models;

public class Character
{
    public Guid CharacterId { get; set; } = Guid.NewGuid();
    public Guid WorkId { get; set; }
    public string Name { get; set; } = string.Empty;

    /// <summary>アイコン絵文字（1文字）</summary>
    public string? IconChar { get; set; }

    /// <summary>プロフィール画像（Base64）</summary>
    public string? ImageBase64 { get; set; }

    public float? Height { get; set; }
    public float? Weight { get; set; }
    public string? Note { get; set; }
}