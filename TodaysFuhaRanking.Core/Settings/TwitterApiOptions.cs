namespace TodaysFuhaRanking.Core.Settings
{
    /// <summary>
    /// Twitter Developers で作成した App から発行される Consumer API keys および Access tokens の設定を表します。
    /// </summary>
    public class TwitterApiOptions
    {
        /// <summary>オプションのキー名</summary>
        public const string KeyName = "TwitterApi";

        /// <summary>
        /// Twitter API キーを取得または設定します。
        /// </summary>
        public string ApiKey { get; set; } = "";

        /// <summary>
        /// Twitter API シークレット キーを取得または設定します。
        /// </summary>
        public string ApiSecretKey { get; set; } = "";

        /// <summary>
        /// アクセス トークンを取得または設定します。
        /// </summary>
        public string AccessToken { get; set; } = "";

        /// <summary>
        /// アクセス トークン シークレットを取得または設定します。
        /// </summary>
        public string AccessTokenSecret { get; set; } = "";

        /// <summary>
        /// <see cref="TwitterApiOptions"/> の新しいインスタンスを生成します。
        /// </summary>
        public TwitterApiOptions() { }
    }
}
