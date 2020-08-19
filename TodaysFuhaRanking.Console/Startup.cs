using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;
using TodaysFuhaRanking.Core.Commands;
using TodaysFuhaRanking.Core.Settings;

namespace TodaysFuhaRanking.Console
{
    /// <summary>
    /// DI コンテナに使用するサービス コレクションのスタートアップを行います。
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// <see cref="Startup"/> の新しいインスタンスを生成します。
        /// </summary>
        public Startup() { }

        /// <summary>
        /// 指定したサービス コレクションを構成します。
        /// </summary>
        /// <param name="services"></param>
        public void Configure(IServiceCollection services)
        {
            ConfigureLogging(services);
            ConfigureAppSettings(services);
            ConfigureRepositories(services);
            ConfigureCommands(services);
        }

        /// <summary>
        /// 指定したサービス コレクションに対してログ出力を構成します。
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureLogging(IServiceCollection services)
        {
            services.AddLogging(builder => builder.AddNLog("NLog.config")); // NLogを使用
        }

        /// <summary>
        /// 指定したサービス コレクションに対してアプリケーション設定を構成します。
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureAppSettings(IServiceCollection services)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AssemblyInfo.DirectoryPath)
                .AddJsonFile("AppSettings.json")
#if DEBUG
                .AddUserSecrets<Startup>() // UserSecretsにデバッグ用の機密データを設定する
#endif
                .Build();

            services.AddSingleton(config.GetSection(TwitterApiOptions.KeyName).Get<TwitterApiOptions>());
            services.AddSingleton(config.GetSection(AggregationOptions.KeyName).Get<AggregationOptions>());
            services.AddSingleton(config.GetSection(TweetStorageOptions.KeyName).Get<TweetStorageOptions>());
            services.AddSingleton(config.GetSection(TextExportOptions.KeyName).Get<TextExportOptions>());
        }

        /// <summary>
        /// 指定したサービス コレクションに対して DB 操作サービスを構成します。
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureRepositories(IServiceCollection services)
        {
            //services.AddSingleton<ISettingsRepository, JsonSettingsRepository>();
            //services.AddSingleton<IFuhaRepository, SqliteFuhaRepository>();
        }

        /// <summary>
        /// 指定したサービス コレクションに対してコマンドを構成します。
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureCommands(IServiceCollection services)
        {
            services.AddTransient<AggregateCommand>();
            services.AddTransient<TweetCommand>();
            services.AddTransient<ExportTextCommand>();
        }
    }
}
