using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class ProjectFinishedLogLine : LogLine
    {
        public ProjectFinishedLogLine(ProjectFinishedEventArgs e) : base(
            $"Project finished: " +
            $"<span class=\"{StyleSheet.ProjectFileNameCssClass}\">{e.ProjectFile}</span> " +
            $"<span class=\"{StyleSheet.MessageCssClass}\">{e.Message}</span> " +
            $" {e.Succeeded}<br/>")
        {
        }
    }

}
