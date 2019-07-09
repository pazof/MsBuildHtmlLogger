using Microsoft.Build.Framework;
using System.Collections.Generic;

namespace HtmlLogger
{
    public static class StyleSheet {

        public static string BgColor = "#000";
        public static string FgColor = "#ccc";
        public static string ErrorMessageCssClass = "error";
        public static string WarningMessageCssClass = "warn";
        public static string MessageCssClass = "msg";
        public static string CodeCssClass = "code";
        public static string FileNameCssClass = "fname";
        public static string ProjectFileNameCssClass = "pname";
        public static string LineColCssStyle = "lncol";
        public static string SenderNameCssClass = "sender";
        public static string AnyEventCssClass = "anyev"; 
        public static string StatusCssClass = "anyev"; 

        public static Dictionary<MessageImportance, string> ImportancesCssClasses;

        public static void Init()
        {
            ImportancesCssClasses = new Dictionary<MessageImportance, string>();
            ImportancesCssClasses[MessageImportance.High] = "high";
            ImportancesCssClasses[MessageImportance.Normal] = null;
            ImportancesCssClasses[MessageImportance.Low] = "low";
        }
    }
}
