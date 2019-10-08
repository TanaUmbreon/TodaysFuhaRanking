namespace EarliestFuhaRanking.Configurations
{
    /// <summary>
    /// Twitter App を操作するためのキーとトークンを格納します。
    /// </summary>
    public class KeysAndTokens
    {
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
        /// <see cref="KeysAndTokens"/> の新しいインスタンスを生成します。
        /// </summary>
        public KeysAndTokens() { }
    }
}
