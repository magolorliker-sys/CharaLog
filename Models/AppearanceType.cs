using MudBlazor;

namespace CharaLog.Models;

public enum AppearanceType
{
    ActiveRole = 0,
    HasDialogue = 1,
    AppearanceOnly = 2,
    MentionOnly = 3
}

public static class AppearanceTypeExtensions
{
    public static string ToDisplayName(this AppearanceType t) => t switch
    {
        AppearanceType.ActiveRole => "活躍あり",
        AppearanceType.HasDialogue => "台詞あり",
        AppearanceType.AppearanceOnly => "姿のみ",
        AppearanceType.MentionOnly => "言及のみ",
        _ => "不明"
    };

    public static Color ToMudColor(this AppearanceType t) => t switch
    {
        AppearanceType.ActiveRole => Color.Info,
        AppearanceType.HasDialogue => Color.Success,
        AppearanceType.AppearanceOnly => Color.Warning,
        AppearanceType.MentionOnly => Color.Default,
        _ => Color.Default
    };
}