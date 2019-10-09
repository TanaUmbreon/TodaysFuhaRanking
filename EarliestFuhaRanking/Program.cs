using System;
using Common;

namespace EarliestFuhaRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApplication.Run(() =>
            {
                // 相対パスの起点を実行ファイルと同じフォルダにする
                Environment.CurrentDirectory = AssemblyInfo.DirectoryPath;

                // メイン処理
                var model = new MainModel();
                model.CollectTweets();
                model.ReportTweets();
            });
        }
    }
}
