namespace CharaLog.Models;

/// <summary>エクスポート／インポート用ルートオブジェクト</summary>
public class AppData
{
    public string Version { get; set; } = "1.0";
    public DateTime ExportedAt { get; set; } = DateTime.UtcNow;
    public List<Work> Works { get; set; } = [];
    public List<Character> Characters { get; set; } = [];
    public List<Appearance> Appearances { get; set; } = [];
}