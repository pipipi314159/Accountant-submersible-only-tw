# Accountant (TW)：潛水艇精簡版

FFXIV 台服（繁中）Dalamud 插件，只保留 **潛水艇探索回航計時**。

本專案是 [Ottermandias/Accountant](https://github.com/Ottermandias/Accountant) 的非官方修改版，已調整為相容台服 Dalamud（API Level 13）。

## 基於版本

- 原版：Accountant 1.8.3.1（commit `f6184b4`，2026-05-08）
- 目標：台服 Dalamud，API Level 13 / .NET 9
- 分支：`main`

## 功能

- 自動讀取潛水艇探索資訊，在計時視窗顯示回航剩餘時間
- 計時資料儲存在本機，重開遊戲後仍會保留

## 與原版的差異

- 只保留潛水艇功能；飛空艇、園藝、金碟、軍隊、地圖等功能已停用
- 調整為 API13，可在台服 Dalamud 上載入
- 插件顯示名稱改為 `Accountant (TW)`，內部名稱仍為 `Accountant`（沿用原本的設定資料夾）
- 修正台服世界名稱（中文）被判定為無效，導致重開遊戲後計時資料被清除的問題
- 讀取計時檔時，驗證失敗的檔案不再被刪除，只會記錄在 log 並保留

## 安裝方式（開發插件）

本專案不提供自動更新，請自行編譯後以開發插件方式載入。

1. 依下方「編譯方式」取得 `Accountant.dll`
2. 遊戲中輸入 `/xlsettings`，開啟 **實驗性功能** 分頁
3. 在「開發插件位置」加入 `Accountant.dll` 的完整路徑，例如：

   ```
   C:\Users\<你的帳號>\Documents\GitHub\Accountant-submersible-only-tw\Accountant\bin\Release\Accountant.dll
   ```

4. 按 `+` 與儲存
5. 輸入 `/xlplugins`，在「開發工具」中載入 **Accountant (TW)**

> 如果之前從自訂插件儲存庫安裝過 Accountant，請先解除安裝，並移除該儲存庫網址，避免兩個同名插件衝突。

## 使用方式

- 在公會工房與潛水艇互動，打開潛水艇面板，插件即會抓取資料
- 之後可在插件的計時視窗查看回航時間
- 資料只會在遊戲中更新；派出潛水艇後請確認計時視窗有顯示

## 編譯方式

需求：.NET 9 SDK，並將環境變數 `DALAMUD_HOME` 設為台服 Dalamud 的資料夾。

```bat
set DALAMUD_HOME=C:\Users\<你的帳號>\AppData\Roaming\FFXIVSimpleLauncher\Dalamud\Injector
dotnet build Accountant\Accountant.csproj -c Release
```

成果會在 `Accountant\bin\Release\`。編譯前請先關閉遊戲或停用插件，否則 DLL 會被鎖定。

## 已知限制

- 僅在台服 Dalamud（API13）測試，國際服請改用[原版插件](https://github.com/Ottermandias/Accountant)
- 遊戲更新後，若 signature 失效，插件可能需要更新才能繼續抓取資料
- 非官方修改版，問題請回報到本專案的 Issues，**不要**打擾原作者

## 授權與致謝

- 原作者：[Ottermandias](https://github.com/Ottermandias)，原專案採 Apache-2.0 授權
- 本專案沿用 Apache-2.0，詳見 [LICENSE](LICENSE)
- 本專案與 Square Enix、原作者無任何官方關係
