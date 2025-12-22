using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Plugin.Maui.Workarounds.MacCatalyst;

public static class Workarounds
{
    public static void OverrideCatalystScaleFactor() => Binding.MacCatalystWorkarounds.OverrideCatalystScaleFactor();

    public static void RedirectNSLogToTrace() => Task.Run(RedirectNSLogToTraceAsync);

    public static async Task RedirectNSLogToTraceAsync()
    {
        int[] fds = new int[2];
        if (pipe(fds) == -1)
        {
            Trace.WriteLine("Failed to create pipe for NSLog redirection.");
            return;
        }

        if (dup2(fds[1], 2) == -1)
        {
            Trace.WriteLine("Failed to redirect stderr for NSLog redirection.");
            return;
        }

        using Microsoft.Win32.SafeHandles.SafeFileHandle fileHandle = new(fds[0], ownsHandle: true);
        using FileStream stream = new(fileHandle, FileAccess.Read);
        using StreamReader sr = new(stream);
        string? line;
        while ((line = await sr.ReadLineAsync()) is not null)
        {
            Trace.WriteLine($"[NSLog] {line}");
        }
    }

    [DllImport("libc")]
    private static extern int pipe(int[] fds);

    [DllImport("libc")]
    private static extern int dup2(int oldfd, int newfd);
}