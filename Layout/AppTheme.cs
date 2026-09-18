using MudBlazor;

namespace CharaLog.Layout;

/// <summary>
/// CharaLog のダークモード用カラーパレット。
/// 背景と文字のコントラストを十分に確保し、可読性を優先して調整しています。
/// </summary>
public static class AppTheme
{
    public static readonly MudTheme Theme = new()
    {
        PaletteDark = new PaletteDark
        {
            Background = "#121317",
            BackgroundGray = "#1B1D24",
            Surface = "#1C1E25",
            DrawerBackground = "#15161C",
            DrawerText = "#E7E7EC",
            DrawerIcon = "#C7C9D3",
            AppbarBackground = "#15161C",
            AppbarText = "#F2F2F5",
            TextPrimary = "#F2F2F5",
            TextSecondary = "#B9BBC6",
            TextDisabled = "rgba(255,255,255,0.4)",
            ActionDefault = "#B9BBC6",
            ActionDisabled = "rgba(255,255,255,0.3)",
            ActionDisabledBackground = "rgba(255,255,255,0.12)",
            Divider = "rgba(255,255,255,0.14)",
            DividerLight = "rgba(255,255,255,0.08)",
            TableLines = "rgba(255,255,255,0.14)",
            LinesDefault = "rgba(255,255,255,0.16)",
            LinesInputs = "rgba(255,255,255,0.35)",
            Dark = "#15161C",
            DarkContrastText = "#F2F2F5",
        }
    };
}
