using apb97.github.io.WebSudoku.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace apb97.github.io.WebSudoku.Extensions;

public static class NavigationManagerExtensions
{
    private const string DestinationKey = "destination";

    public static async Task NavigateToStoredDestinationIfAnyAsync(this NavigationManager navigation, IJSRuntime js)
    {
        await using var utilitiesModule = await js.ImportAsync(JSModules.UtilitiesModule);
        var destination = await utilitiesModule.GetSessionSettingAsync<string>(DestinationKey);
        if (string.IsNullOrEmpty(destination)) return;
        await utilitiesModule.RemoveSessionSettingAsync(DestinationKey);
        navigation.NavigateTo(destination[1..]);
    }
}
