﻿using Microsoft.JSInterop;

namespace apb97.github.io.WebSudoku.Extensions;

public static class JSRuntimeExtensions
{
    private const string ImportFunction = "import";

    public static async ValueTask<IJSObjectReference> ImportAsync(this IJSRuntime js, string path)
    {
        return await js.InvokeAsync<IJSObjectReference>(ImportFunction, path);
    }
}
