using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class CustomEventLogLine : LogLine
    {
        public CustomEventLogLine(CustomBuildEventArgs e) :
            base($"<p class=\"{StyleSheet.MessageCssClass}\">Error : <span class=\"{StyleSheet.CodeCssClass}\"></span>" +
                $" <span class=\"{StyleSheet.SenderNameCssClass}\">{e.SenderName}</span> " +
                $"<span class=\"{StyleSheet.MessageCssClass}\">{e.Message}</span></p>")
        {
        }
    }
}
