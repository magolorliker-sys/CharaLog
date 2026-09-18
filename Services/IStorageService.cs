using CharaLog.Models;

namespace CharaLog.Services;

public interface IStorageService
{
    // Works
    Task<List<Work>> GetWorksAsync();
    Task SaveWorksAsync(List<Work> works);

    // Characters
    Task<List<Character>> GetCharactersAsync();
    Task SaveCharactersAsync(List<Character> characters);

    // Appearances
    Task<List<Appearance>> GetAppearancesAsync();
    Task SaveAppearancesAsync(List<Appearance> appearances);

    // Export / Import
    Task<AppData> ExportAllAsync();
    Task ImportAllAsync(AppData data, bool overwrite);
}