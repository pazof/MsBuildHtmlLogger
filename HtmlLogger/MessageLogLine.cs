using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class MessageLogLine : LogLine
    {
        public MessageLogLine(BuildMessageEventArgs e)
        {
            string lineColeInfo = GetLineColInfo(e.LineNumber,
                e.ColumnNumber, e.EndLineNumber, e.EndColumnNumber);
            _content =
            $"<p class=\"{StyleSheet.MessageCssClass} {e.Subcategory} " +
                $"{StyleSheet.ImportancesCssClasses[e.Importance]}\">Message : " +
                $"<span class=\"{StyleSheet.CodeCssClass}\">{e.Code}</span> " +
                $"<span class=\"{StyleSheet.ProjectFileNameCssClass}\">{e.ProjectFile}</span> " +
                $"<span class=\"{StyleSheet.FileNameCssClass}\">{e.File}</span>:<span class=\"{StyleSheet.LineColCssStyle}\">{lineColeInfo}</span>  " +
                $"<span class=\"{StyleSheet.MessageCssClass}\">{e.Message}</span></p>";
        }
    }
}
