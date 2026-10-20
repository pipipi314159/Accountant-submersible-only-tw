# Accountant（潛水艇精簡版・台服 API13）

FFXIV 台服（繁中）Dalamud 插件，只保留 **潛水艇探索回航計時**。

本專案是 [Ottermandias/Accountant](https://github.com/Ottermandias/Accountant) 的非官方修改版，基於 v1.8.3.1，已調整為相容台服 Dalamud（API Level 13）。

## 功能

- 自動讀取你的潛水艇探索資訊，在計時視窗顯示回航剩餘時間
- 計時資料會儲存在本機，重開遊戲後仍會保留

## 與原版的差異

- 只保留潛水艇功能；飛空艇、園藝、金碟、軍隊、地圖等功能已停用
- 調整為 API13 / .NET 9，可在台服 Dalamud 上載入
- 修正台服世界名稱（中文）被判定為無效，導致重開遊戲後計時資料被清除的問題

## 安裝方式

1. 遊戲中輸入 `/xlsettings`，開啟 **實驗** 分頁
2. 在「自訂插件儲存庫」新增以下網址，並按 `+` 與儲存：

   ```
   https://raw.githubusercontent.com/pipipi314159/Accountant-submersible-only-tw/main/repo.json
   ```

3. 輸入 `/xlplugins`，在插件列表搜尋 **Accountant** 並安裝

## 使用方式

- 開啟遊戲內的潛水艇面板（在公會工房與潛水艇互動），插件即會抓取資料
- 之後即可在插件的計時視窗查看回航時間
- 指令與設定請輸入 `/accountant`（若無反應，請在 `/xlplugins` 中確認插件已啟用）

## 已知限制

- 僅在台服 Dalamud（API13）測試，國際服請改用[原版插件](https://github.com/Ottermandias/Accountant)
- 遊戲更新後，若 signature 失效，插件可能需要更新才能繼續抓取資料
- 非官方修改版，出問題請回報到本專案的 Issues，**不要**去打擾原作者

## 自行編譯

需求：.NET 9 SDK，並將環境變數 `DALAMUD_HOME` 設為台服 Dalamud 資料夾。

```
dotnet build -c Release
```

成果會在 `Accountant\bin\Release\`（含 `latest.zip`）。

## 授權與致謝

- 原作者：[Ottermandias](https://github.com/Ottermandias)，原專案採 Apache-2.0 授權
- 本專案沿用 Apache-2.0，詳見 [LICENSE](LICENSE)
- 本專案與 Square Enix、原作者無任何官方關係
