# README (TodaysFuhaRanking.Console)

## コンフィグファイル (AppSettings.json) について

UserSecrets を利用し、ローカル開発環境で使用するが、バージョン管理に含めるべきでない機密情報 (Twitter API のシークレットキー情報等) を分離するようにしています。

この UserSecrets の利用はプロジェクト構成が Debug 構成時のみに適用され、 Release 構成時には適用されません。 (`Startup.cs` にて制御)

### UserSecrets とは

UserSecrets を利用することで、コンフィグファイルを公開用 (リポジトリ管理対象) と非公開用 (ローカル開発環境) に使い分けることができるようになります。この非公開用に使われるファイルが UserSecrets です。主に ASP.NET Core で使われています。

UserSecrets がある場合、本来利用されるコンフィグファイルの代わりに利用されます。UserSecrets がない場合は本来利用されるコンフィグファイルが利用されます。

UserSecrets はプロジェクトツリーから隔離された場所で管理します。(`%APPDATA%\Microsoft\UserSecrets\<UserSecretsId>\secrets.json`)

`<UserSecretsId>` は、プロジェクトファイル (*.csproj) の `<PropertyGroup>.<UserSecretsId>` に定義した GUID が使用されます。

UserSecrets ファイルは平文のテキストファイルのため、あくまで開発目的のみで使用されます。

ASP.NET Core では UserSecrets を容易に管理するためのツールが Visual Studio のメニュー拡張として自動で追加されますが、他の開発プロジェクトでは追加されません。そのため、ここでは同様の機能を持った拡張機能「Open UserSecrets」を使用しています。

### 参考ページ

- [【.NET Core】ConfigurationBuilderを使ってC#で設定ファイルや環境変数を扱う](https://tech-blog.cloud-config.jp/2019-7-11-how-to-configuration-builder/)
- [[.NET Core] コンソールアプリケーションで Secret Manager を使う方法](https://mseeeen.msen.jp/add-user-secrets-to-console-app/)
- [非ASP.NET Coreなプロジェクトで UserSecretsを使うためのVisual Studio 拡張を作りました](https://tech.guitarrapc.com/entry/2019/05/01/033007)
