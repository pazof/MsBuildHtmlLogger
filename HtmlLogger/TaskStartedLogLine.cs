using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class TaskStartedLogLine : LogLine
    {
        public TaskStartedLogLine(TaskStartedEventArgs e) : base(
            $"Task {e.TaskName} started for " +
            $"<span class=\"{StyleSheet.ProjectFileNameCssClass}\">{e.ProjectFile}</span> " +
            $"<span class=\"{StyleSheet.MessageCssClass}\">{e.Message}</span> <br/>")
        {
        }
    }
}
