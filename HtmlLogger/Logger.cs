using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HtmlLogger
{

    public class Logger : ILogger
    {
        Queue<HtmlChunk> HtmlQueue = new Queue<HtmlChunk>();
        public LoggerVerbosity Verbosity { get ; set; }
        public string Parameters { get; set; }
        CancellationTokenSource cancellationTokenSource;
        private Task writtingTask;
        private StreamWriter stream;
        private FileInfo file;

        public void Initialize(IEventSource eventSource)
        {
            StyleSheet.Init();

            eventSource.BuildStarted += EventSource_BuildStarted;
            eventSource.BuildFinished += EventSource_BuildFinished;

            eventSource.StatusEventRaised += EventSource_StatusEventRaised;

            eventSource.ProjectStarted += EventSource_ProjectStarted;
            eventSource.ProjectFinished += EventSource_ProjectFinished;

            eventSource.TargetStarted += EventSource_TargetStarted;
            eventSource.TargetFinished += EventSource_TargetFinished;

            eventSource.TaskFinished += EventSource_TaskFinished;
            eventSource.TaskStarted += EventSource_TaskStarted;

            eventSource.MessageRaised += EventSource_MessageRaised;
            eventSource.WarningRaised += EventSource_WarningRaised;
            eventSource.ErrorRaised += EventSource_ErrorRaised;
            cancellationTokenSource = new CancellationTokenSource();
            eventSource.CustomEventRaised += EventSource_CustomEventRaised;
            DirectoryInfo dirInf = new DirectoryInfo("BuildLogging");
            if (dirInf.Exists == false)
            {
                dirInf.Create();
            }

            file = new FileInfo("build.log." + DateTime.Now.ToString("MMddyy_HHmmss") + ".html");
            if (file.Exists)
            {
                file.Delete();
            }

            stream = new StreamWriter(file.FullName, true);

            writtingTask = Task.Run(() => {
                do
                {
                    if (HtmlQueue.Count <= 0)
                    {
                        Task.Delay(100).Wait();
                    }
                    else
                    {
                        var line = HtmlQueue.Dequeue();
                        stream.WriteLine(line.Render());
                        stream.Flush();
                    }
                } while (!cancellationTokenSource.IsCancellationRequested || HtmlQueue.Count>0);
            });

            HtmlQueue.Enqueue(new LogLine("<!doctype html>\n<html><head><meta charset=\"utf-8\" />" +
    $"<style>\n.{StyleSheet.ErrorMessageCssClass} " + "{ color: #f33; background-color:black; }\n" +
    $".{StyleSheet.WarningMessageCssClass} " + "{ color: #f83; background-color:black; }\n" +
    $".high " + "{ font-size: large; }\n" +
    $".{StyleSheet.ProjectFileNameCssClass} " + "{ color: #fff; background-color:#040; font-family: monospace; }\n" +
    "body { color: " + StyleSheet.FgColor + "; background-color: " + StyleSheet.BgColor +

    
    "}\n</style>" +
    "</head><body>"));
        }

        private void EventSource_CustomEventRaised(object sender, CustomBuildEventArgs e)
        {
            HtmlQueue.Enqueue(new CustomEventLogLine(e));
        }

        private void EventSource_MessageRaised(object sender, BuildMessageEventArgs e)
        {
            if (e.Importance == MessageImportance.High || e.Importance == MessageImportance.Normal && Verbosity >= LoggerVerbosity.Normal
                || e.Importance == MessageImportance.Low && Verbosity >= LoggerVerbosity.Diagnostic)
                HtmlQueue.Enqueue(new MessageLogLine(e));
        }

        private void EventSource_WarningRaised(object sender, BuildWarningEventArgs e)
        {
            HtmlQueue.Enqueue(new WarningLogLine(e));
        }

        private void EventSource_ErrorRaised(object sender, BuildErrorEventArgs e)
        {
            HtmlQueue.Enqueue(new ErrorLogLine(e));
        }

        private void EventSource_TargetStarted(object sender, TargetStartedEventArgs e)
        {
            if ( Verbosity >= LoggerVerbosity.Diagnostic)
                HtmlQueue.Enqueue(new TargetStartedLogLine(e));
        }

        private void EventSource_TargetFinished(object sender, TargetFinishedEventArgs e)
        {
            if (Verbosity >= LoggerVerbosity.Diagnostic)
                HtmlQueue.Enqueue(new TargetFinishedLogLine(e));
        }

        private void EventSource_TaskStarted(object sender, TaskStartedEventArgs e)
        {
            if (Verbosity >= LoggerVerbosity.Diagnostic)
                HtmlQueue.Enqueue(new TaskStartedLogLine(e));
        }

        private void EventSource_TaskFinished(object sender, TaskFinishedEventArgs e)
        {
            if (Verbosity >= LoggerVerbosity.Diagnostic)
                HtmlQueue.Enqueue(new TaskFinishedLogLine(e));
        }

        private void EventSource_ProjectStarted(object sender, ProjectStartedEventArgs e)
        {
            if (Verbosity >= LoggerVerbosity.Diagnostic)
                HtmlQueue.Enqueue(new ProjectStartedLogLine(e));
        }

        private void EventSource_ProjectFinished(object sender, ProjectFinishedEventArgs e)
        {
            if (Verbosity >= LoggerVerbosity.Diagnostic)
                HtmlQueue.Enqueue(new ProjectFinishedLogLine(e));
        }

        private void EventSource_StatusEventRaised(object sender, BuildStatusEventArgs e)
        {
            if (Verbosity >= LoggerVerbosity.Diagnostic)
                HtmlQueue.Enqueue(new LogLine($"<span class=\"{StyleSheet.StatusCssClass}\">{e.Message} - {e.HelpKeyword}</span>"));
        }

        private void EventSource_BuildStarted(object sender, BuildStartedEventArgs e)
        {
            if (Verbosity >= LoggerVerbosity.Normal)
                HtmlQueue.Enqueue(new BuildStartedLogLine(e));
        }

        private void EventSource_BuildFinished(object sender, BuildFinishedEventArgs e)
        {
            if (Verbosity >= LoggerVerbosity.Normal)
                HtmlQueue.Enqueue(new BuildFinishedLogLine(e));
        }

        public void Shutdown()
        {
            HtmlQueue.Enqueue(new LogLine("</body></html>"));
            cancellationTokenSource.Cancel();
            writtingTask.Wait();

            stream.Close();
            stream.Dispose();
        }
    }
}
