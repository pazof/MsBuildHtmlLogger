using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class BuildStartedLogLine : LogLine
    {
        public BuildStartedLogLine(BuildStartedEventArgs e) : base(
            $"<strong><em><span class=\"{StyleSheet.MessageCssClass}\">{Localisation.BuildStarted}" +
            $"</span></em></strong><br/>")
        {
        }
    }

}
