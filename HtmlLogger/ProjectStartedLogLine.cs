using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class ProjectStartedLogLine : LogLine
    {
        public ProjectStartedLogLine(ProjectStartedEventArgs e) : base(
            $"{Localisation.Started}: {e.ProjectId} " +
            $"<span class=\"{StyleSheet.ProjectFileNameCssClass}\">{e.ProjectFile}</span> " +
            $"<span class=\"{StyleSheet.MessageCssClass}\">{e.Message}</span> <br/>")
        {
        }
    }
}
