using MudBlazor;

namespace CharaLog.Layout;

/// <summary>
/// CharaLog のダークモード用カラーパレット。
/// 黒(#000000)と深緑(#003221)を基調に、ヘッダー・サイドバーには#003221を、
/// ページ背景には黒を使用。ボタンやアクティブ状態が背景に埋もれないよう、
/// 同じ緑系統からやや明るいトーン(#0E9A6B)をアクセントカラーとして使用しています。
/// </summary>
public static class AppTheme
{
    public static readonly MudTheme Theme = new()
    {
        PaletteDark = new PaletteDark
        {
            Primary = "#0E9A6B",
            PrimaryContrastText = "#04120C",
            Background = "#000000",
            BackgroundGray = "#0D1F17",
            Surface = "#0D1F17",
            DrawerBackground = "#003221",
            DrawerText = "#F2F2F5",
            DrawerIcon = "#C7C9D3",
            AppbarBackground = "#003221",
            AppbarText = "#F2F2F5",
            TextPrimary = "#F2F2F5",
            TextSecondary = "#9DBBAD",
            TextDisabled = "rgba(255,255,255,0.4)",
            ActionDefault = "#9DBBAD",
            ActionDisabled = "rgba(255,255,255,0.3)",
            ActionDisabledBackground = "rgba(255,255,255,0.12)",
            Divider = "rgba(255,255,255,0.14)",
            DividerLight = "rgba(255,255,255,0.08)",
            TableLines = "rgba(255,255,255,0.14)",
            LinesDefault = "rgba(255,255,255,0.16)",
            LinesInputs = "rgba(255,255,255,0.35)",
            Dark = "#003221",
            DarkContrastText = "#F2F2F5",
        }
    };
}
