using Blazored.LocalStorage;

namespace SmartDj.Gui.Services;

public class SettingService(ILocalStorageService localStorage)
{
    private string? _baseAddress;
    public async Task<string?> GetBaseAddress()
    {
        if (string.IsNullOrEmpty(_baseAddress))
        {
            _baseAddress = await localStorage.GetItemAsync<string>("baseAddress");
            if (string.IsNullOrEmpty(_baseAddress))
            {
                _baseAddress = "http://localhost:8080/";
            }
        }
        return _baseAddress;
    }

    public async Task<bool> AddBaseAddress(string value)
    {
        return await AddToLocalStorage("baseAddress", value);
    }
    
    public async Task<bool> AddToLocalStorage(string key, string value)
    {
        try
        {
            await localStorage.SetItemAsync(key, value);
            return true;
        }
        catch
        {
            return false;
        }
        
    }
}