using System.IO;
using NUnit.Framework;
using TodaysFuhaRanking.Settings;

namespace TodaysFuhaRanking.Test.Settings
{
    [TestFixture]
    public class TextReportSettingsTest
    {
        [Test]
        public void InitializedValues()
        {
            var settings = new TextReportSettings();

            Assert.That(settings.SaveDirectoryPath, Is.Empty);
            Assert.That(settings.DetailReportFilePath, Is.Empty);
            Assert.That(settings.TweetReportFilePath, Is.Empty);
            Assert.That(settings.EncodingName, Is.Empty);
        }

        [Test]
        public void CreateDetailReportWriter()
        {
            var settings = new TextReportSettings();
            Assert.That(() => settings.CreateDetailReportWriter(), Throws.InvalidOperationException);

            settings.DetailReportFilePath = Path.GetTempFileName();
            Assert.That(() => settings.CreateDetailReportWriter(), Throws.ArgumentException);

            settings.EncodingName = "Freegeo";
            Assert.That(() => settings.CreateDetailReportWriter(), Throws.ArgumentException);

            try
            {
                settings.EncodingName = "UTF-8";
                using var w = settings.CreateDetailReportWriter();
                Assert.That(w, Is.TypeOf<StreamWriter>());
            }
            finally
            {
                File.Delete(settings.DetailReportFilePath);
            }
        }

        [Test]
        public void CreateTweetReportWriter()
        {
            var settings = new TextReportSettings();
            Assert.That(() => settings.CreateTweetReportWriter(), Throws.InvalidOperationException);

            settings.TweetReportFilePath = Path.GetTempFileName();
            Assert.That(() => settings.CreateTweetReportWriter(), Throws.ArgumentException);

            settings.EncodingName = "Freegeo";
            Assert.That(() => settings.CreateTweetReportWriter(), Throws.ArgumentException);

            try
            {
                settings.EncodingName = "UTF-8";
                using var w = settings.CreateTweetReportWriter();
                Assert.That(w, Is.TypeOf<StreamWriter>());
            }
            finally
            {
                File.Delete(settings.TweetReportFilePath);
            }
        }
    }
}
