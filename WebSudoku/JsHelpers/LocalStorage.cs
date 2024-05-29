using Microsoft.JSInterop;

namespace WebSudoku.JsHelpers
{
    public sealed class LocalStorage
    {
        private readonly IJSRuntime js;

        private const string SetItemFunction = "localStorage.setItem";
        private const string GetItemFunction = "localStorage.getItem";

        public LocalStorage(IJSRuntime js)
        {
            this.js = js;
        }

        public async Task SetItem(string key, string? value)
        {
            await js.InvokeVoidAsync(SetItemFunction, key, value);
        }

        public async Task<string> GetItem(string key)
        {
            return await js.InvokeAsync<string>(GetItemFunction, key);
        }
    }
}
