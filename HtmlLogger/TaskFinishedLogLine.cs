using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class TaskFinishedLogLine : LogLine
    {
        public TaskFinishedLogLine(TaskFinishedEventArgs e) : base(
            $"Task {e.TaskName} finished for " +
            $"<span class=\"{StyleSheet.ProjectFileNameCssClass}\">{e.ProjectFile}</span> " +
            $"<span class=\"{StyleSheet.MessageCssClass}\">{e.Message}</span> " +
            $" {e.Succeeded}<br/>")
        {
        }
    }
}
