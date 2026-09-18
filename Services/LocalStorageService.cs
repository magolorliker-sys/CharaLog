using System.Text.Json;
using CharaLog.Models;
using Microsoft.JSInterop;

namespace CharaLog.Services;

public class LocalStorageService(IJSRuntime js) : IStorageService
{
    private static readonly JsonSerializerOptions _opts = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    // ── 汎用ヘルパー ─────────────────────────────
    private async Task<T> GetAsync<T>(string key) where T : new()
    {
        var json = await js.InvokeAsync<string?>("localStorage.getItem", key);
        if (string.IsNullOrEmpty(json)) return new T();
        return JsonSerializer.Deserialize<T>(json, _opts) ?? new T();
    }

    private async Task SetAsync<T>(string key, T value)
    {
        var json = JsonSerializer.Serialize(value, _opts);
        await js.InvokeVoidAsync("localStorage.setItem", key, json);
    }

    // ── Works ────────────────────────────────────
    public Task<List<Work>> GetWorksAsync() => GetAsync<List<Work>>("cl_works");
    public Task SaveWorksAsync(List<Work> w) => SetAsync("cl_works", w);

    // ── Characters ───────────────────────────────
    public Task<List<Character>> GetCharactersAsync() => GetAsync<List<Character>>("cl_chars");
    public Task SaveCharactersAsync(List<Character> c) => SetAsync("cl_chars", c);

    // ── Appearances ──────────────────────────────
    public Task<List<Appearance>> GetAppearancesAsync() => GetAsync<List<Appearance>>("cl_app");
    public Task SaveAppearancesAsync(List<Appearance> a) => SetAsync("cl_app", a);

    // ── Export ───────────────────────────────────
    public async Task<AppData> ExportAllAsync() => new AppData
    {
        Works = await GetWorksAsync(),
        Characters = await GetCharactersAsync(),
        Appearances = await GetAppearancesAsync(),
        ExportedAt = DateTime.UtcNow
    };

    // ── Import ───────────────────────────────────
    public async Task ImportAllAsync(AppData data, bool overwrite)
    {
        if (overwrite)
        {
            await SaveWorksAsync(data.Works);
            await SaveCharactersAsync(data.Characters);
            await SaveAppearancesAsync(data.Appearances);
            return;
        }

        // 追記：既存IDと重複しないものだけ追加
        var works = await GetWorksAsync();
        var chars = await GetCharactersAsync();
        var apps = await GetAppearancesAsync();

        var wIds = works.Select(x => x.WorkId).ToHashSet();
        var cIds = chars.Select(x => x.CharacterId).ToHashSet();
        var aIds = apps.Select(x => x.AppearanceId).ToHashSet();

        works.AddRange(data.Works.Where(x => !wIds.Contains(x.WorkId)));
        chars.AddRange(data.Characters.Where(x => !cIds.Contains(x.CharacterId)));
        apps.AddRange(data.Appearances.Where(x => !aIds.Contains(x.AppearanceId)));

        await SaveWorksAsync(works);
        await SaveCharactersAsync(chars);
        await SaveAppearancesAsync(apps);
    }
}