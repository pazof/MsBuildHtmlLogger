using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class BuildFinishedLogLine : LogLine
    {
        public BuildFinishedLogLine(BuildFinishedEventArgs e) : base(
            $"<span class=\"{StyleSheet.MessageCssClass}\">{Localisation.BuildFinished} " +
            $" {(e.Succeeded?Localisation.InSuccess:Localisation.InError)}</span><br/>")
        {
        }
    }

}
