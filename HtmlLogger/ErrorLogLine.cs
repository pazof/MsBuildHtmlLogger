using Microsoft.Build.Framework;

namespace HtmlLogger
{
    public class ErrorLogLine : LogLine
    {
        public ErrorLogLine(BuildErrorEventArgs e) :
            base($"<p class=\"{StyleSheet.ErrorMessageCssClass} {e.Subcategory}\">Error : " +
                $"<span class=\"{StyleSheet.CodeCssClass}\">{e.Code}</span> " +
                $"<span class=\"{StyleSheet.ProjectFileNameCssClass}\">{e.ProjectFile}</span> " +
                $"<span class=\"{StyleSheet.FileNameCssClass}\">{e.File}</span>:" +
                $"<span class=\"{StyleSheet.LineColCssStyle}\">{e.LineNumber}:{e.ColumnNumber} - {e.EndLineNumber}:{e.EndColumnNumber}</span>  " +
                $"<span class=\"{StyleSheet.MessageCssClass}\">{e.Message}</span></p>")
        {
        }
    }
}
