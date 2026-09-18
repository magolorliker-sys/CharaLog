namespace CharaLog.Models;

public class Work
{
    public Guid WorkId { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public int TotalEpisodes { get; set; } = 1;
    public Genre Genre { get; set; } = Genre.Anime;
    public string? Note { get; set; }

    /// <summary>話ごとのサブタイトル一覧</summary>
    public List<Episode> Episodes { get; set; } = [];
}