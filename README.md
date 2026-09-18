# CharaLog

キャラクター登場記録アプリ（Blazor WebAssembly + MudBlazor）。

- 公開サイト: https://magolorliker-sys.github.io/CharaLog/
- `main` ブランチに push すると GitHub Actions が自動でビルドし、`gh-pages` ブランチに公開用ファイルを配置します。

## ローカルで動かす

```
dotnet run
```

`start-charalog.bat` を実行してもローカルサーバーが起動します。

## データの保存・移動について

すべてのデータ（作品・キャラクター・登場記録）はブラウザの localStorage に保存されます。
「設定」画面からデータ全体を JSON ファイルとして書き出し・読み込みできるため、
スマートフォンと PC など異なる端末間でのデータ移動はこの JSON ファイルを使って行ってください。

- エクスポート: 設定 → JSONをダウンロード
- インポート: 設定 → JSONファイルを選択（既存データへの追記／上書きを選択可能）
