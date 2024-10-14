using Microsoft.JSInterop;

namespace WebSudoku.Extensions
{
    public static class JSObjectReferenceExtensions
    {
        private const string AlertFunction = "alert";
        private const string SetSettingFunction = "setSetting";
        private const string GetSettingFunction = "getSetting";

        /// <summary>
        /// Show simple alert message
        /// </summary>
        /// <param name="utilitiesModule">JavaScript Module "./js/utilities.js"</param>
        /// <param name="message">Message to be shown</param>
        public static async Task Alert(this IJSObjectReference utilitiesModule, string message)
        {
            await utilitiesModule.InvokeVoidAsync(AlertFunction, message);
        }

        /// <summary>
        /// Set setting in localStorage
        /// </summary>
        /// <param name="utilitiesModule">JavaScript Module "./js/utilities.js"</param>
        public static async Task SetSetting<T>(this IJSObjectReference utilitiesModule, string key, T value)
        {
            await utilitiesModule.InvokeVoidAsync(SetSettingFunction, key, value);
        }

        /// <summary>
        /// Get setting from localStorage
        /// </summary>
        /// <param name="utilitiesModule">JavaScript Module "./js/utilities.js"</param>
        public static async Task<T?> GetSetting<T>(this IJSObjectReference utilitiesModule, string key)
        {
            return await utilitiesModule.InvokeAsync<T>(GetSettingFunction, key);
        }
    }
}
