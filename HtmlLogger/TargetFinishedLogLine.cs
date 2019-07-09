using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class TargetFinishedLogLine : LogLine
    {
        public TargetFinishedLogLine(TargetFinishedEventArgs e) : base(
            $"{Localisation.Target} {e.TargetName} {Localisation.Finished} " +
            $"<span class=\"{StyleSheet.ProjectFileNameCssClass}\">{e.ProjectFile}</span> " +
            $"<span class=\"{StyleSheet.MessageCssClass}\">{e.Message}</span> " +
             $" {(e.Succeeded ? Localisation.InSuccess : Localisation.InError)}<br/>")
        {
        }
    }
}
