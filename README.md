[webview2Settings]: https://learn.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.core.corewebview2settings "CoreWebView2Settings Class"
[darkthread]: https://blog.darkthread.net/ "黑暗執行緒"

Blog: https://felicnoblog.blogspot.com/2023/02/first.html

# WebViewForm.Core

點子是從 [黑暗大][darkthread] 的Minimal API及微軟出的WebView2來的，我就想既然有了WebView2，應該可以用C#做出類似Node.js+Electron的程式，於是這支樣板就寫出來了😆

所以這就是一個WinForm套`WebView2`瀏覽網站的程式，網站類似MVC，前端使用靜態網頁`.html`，利用Ajax呼叫後端的Controller，再把值傳回去。

目前遇到的問題是沒辦法使用View，因為WinForm不會去編譯，所以才用靜態網頁`.html`。

建議使用.NET 6以上版本。

## 程式結構

### Program.cs

使用`WebHost`建立伺服器，並設定動態Port，建立完成之後將相關參數帶到`MainForm`。

### Startup.cs

用來設定`WebHost`。

### MainForm.cs

用來放`WebView2`的`Form`。

因為使用動態Port，所以這支程式要接WebHost的設定，取得Port之後再帶到`WebView2`。

`WebView2`的設定請參考 [CoreWebView2Settings Class][webview2Settings] 。

### Controllers/

放MVC的Controller，應該都知道吧🤣

### wwwroot/

放靜態檔案。

我在這邊放`.html`檔，用JavaScript向後端傳遞資料。

### 其他要注意的地方

如果用VS.NET寫程式，在wwwroot加入檔案的時候，`.csproj`會多出`ItemGroup`，請把那些多的刪掉，只要留下面的`ItemGroup`就好。

```csproj
<ItemGroup>
  <Content Include="wwwroot\**" Link="$(OutputRoot)\wwwroot\%(RecursiveDir)%(Filename)%(Extension)" CopyToOutputDirectory="Always" />
</ItemGroup>
```

這段會在編譯時將檔案複製過去，就不用一個一個設定。