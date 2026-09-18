using MudBlazor;

namespace CharaLog.Models;

public enum Genre
{
    Anime = 0,  // アニメ
    Game = 1,  // ゲーム
    Movie = 2,  // 映画
    Tokusatsu = 3, // 特撮
    Other = 4   // その他
}
//私的メモ：ジャンルを増やしたい場合はGene.csを変更する。
public static class GenreExtensions
{
    public static string ToDisplayName(this Genre g) => g switch
    {
        Genre.Anime => "アニメ",
        Genre.Game => "ゲーム",
        Genre.Movie => "映画",
        Genre.Tokusatsu => "特撮",
        Genre.Other => "その他",
        _ => "不明"
    };

    public static string ToIcon(this Genre g) => g switch
    {
        Genre.Anime => Icons.Material.Filled.Tv,
        Genre.Game => Icons.Material.Filled.SportsEsports,
        Genre.Movie => Icons.Material.Filled.Movie,
        Genre.Tokusatsu => Icons.Material.Filled.FlashOn,
        Genre.Other => Icons.Material.Filled.Category,
        _ => Icons.Material.Filled.Category
    };
}