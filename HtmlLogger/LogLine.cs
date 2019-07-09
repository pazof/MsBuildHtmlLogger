namespace HtmlLogger
{
    public class LogLine : HtmlChunk
    {
        protected string _content;

        public LogLine()
        {
        }

        public LogLine(string content)
        {
            _content = content;
        }

        public override string Render()
        {
            return _content;
        }

        public string GetLineColInfo(int line, int col, int endline, int endcol)
        {
            if (line == 0 && col == 0 && endline == 0 && endcol == 0) return null;
            if (line == endline) {
                if (col == endcol)
                {
                    return $"{line}:{col}";
                }
                else return $"{line}:{col}..{endcol}";
            }
            else return $"{line}:{col}..{endline}:{endcol}";
        }
    }
}
