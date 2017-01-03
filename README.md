# MyUseWizardsLib
架構設計好簡單系列(3) - 設計自己簡單的 ORM 平台 - (範例與原始碼)

感謝許多人來上小弟的前次課程 『如何有架構性將現有 ASP.NET WebForm 轉換為MVC？ 』，這個課程也開到了第三梯次，小編預計在 2016/03/26 將在開全新的課程 『架構設計好簡單系列 - 設計符合團隊的範本精靈 (Project Template)』，這是小編重新設計的課程，若您沒有聽過小編的前一次『如何有架構性將現有 ASP.NET WebForm 轉換為MVC？ 』課程也沒有關係，因為前一課程比較偏重開發，本課程比較偏重管理面。

如果您想了解在團隊中，如何導入 Project Templates，以及為什麼使用 Project Templates 後還要使用範本精靈？範本精靈使用的時機點為何？各有什麼優缺點？取捨點在哪裡？

以及什麼時候該使用自訂的 NuGet Package？什麼時候該自訂 Project Templates？怎麼那捏？還有團隊中進行 Code Review 的時機點？StyleCop 怎麼在團隊中使用？以及怎麼樣結合前面的流程讓 Code Review 變得更有效率。課程中小編將以做顧問時帶某科學園區的實際協助導入經驗來跟大家分享。

如果您是 Programming Leader 或是如果您對 Visual Studio 範本精靈的設計有興趣，或是您想了解如何透過範本精靈來減低重複性的工作、或加速開發、或在範本中建立屬於您團隊的 Coding Standard or Programming Rule 都歡迎來參加此課程。

課程：架構設計好簡單系列 - 設計符合團隊的範本精靈 (Project Template)
課程大綱

1. 為什麼要製作範本精靈 （談談軟體專案開發這件事情）
2. 多人的團隊如何制定一致性的團隊的開發規範 - Coding Standard (Programming Rule)
3. 加速開發 - 避免重複造輪子
4. 如何保障程式碼品質 (搭配 UnitTest & Code Review)
5. 讓程式碼便於交接、維護、與重用
7. 一致性的團隊的開發規範 - Coding Standard (Programming Rule)
8. 談原始碼管控的重要性
9. Visual Studio Project Template 概念 (Project Template vs. NuGet Package?)
10. 實作

從企業內部控管流程來談

如何開始？困難點有哪一些？
1. 減低重複性的工作
    可透過一些現有的工具、或是自行開發一些 Tool 來解決問題
    結合前一次課程『如何將現有 Web Form 轉換到MVC』所提到到的架構設計概念 與 Design Pattern
    避免不必要的浪費
2. 建立團隊開發的共同規範 - Coding Standard (Programming Rule)
    程式碼品質並不是有 Project Template + Framework 就可以解決。還必須搭配 Unit Test、Code Review 來達成
    制定規範
        Coding Standard (Programming Rule) 程式碼撰寫規範
        Visual Studio 專案切割方式都要加以定義
        分層方式 (.aspx 不應該出現存取資料庫的敘述)
        所以：這些規範就必須加入待會的 Project Template 中，使 Template 建立出來的程式碼即是符合上方的 "Coding Standard (Programming Rule) 程式碼撰寫規範"
3. 建立重用性的元件，起碼必須分層，彼此耦合度低，並真正使用適當的 Design Pattern
    DAL
    Business Logic
    Common Utlity
4. 將 Common Utlity 規劃為 NuGet Package

5. 開始設計我們的第一個 Project Template
    A. 設計一個 ASP.NET MVC5 的範本
    (1). 使用 NuGet 設定自動還原、設定 RestorePackage、與 BuildPackage
    (2). 使用 ClassLibrary 自動包裝一個 NuGet Package 的 DAL 元件
    (3). 使用 Visual Studio SDK Extensibility 建立 C# Project Template
    (4). 編輯 .vstemplate 與 貼上相關需要的 .cs .js (團隊已經預先定義好的 Programming Rule/Coding Standard)
    (5). 編輯 ProjectTemplate.csproj
    (6). 建立 VSIX Project
    (7). 透過 VSIX Project (編輯／佈署) 自己的 Project Template
