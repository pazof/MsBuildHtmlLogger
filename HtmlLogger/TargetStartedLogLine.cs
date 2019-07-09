using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class TargetStartedLogLine : LogLine
    {
        public TargetStartedLogLine(TargetStartedEventArgs e) : base(
            $"Target {e.TargetName} Started for " +
            $"<span class=\"{StyleSheet.ProjectFileNameCssClass}\">{e.ProjectFile}</span> " +
            $"<span class=\"{StyleSheet.MessageCssClass}\">{e.Message}</span><br/> " )
        {
        }
    }
}
