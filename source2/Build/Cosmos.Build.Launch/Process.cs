﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cosmos.Build.Launch {
  public class Process {
    public static void Execute(string aEXEPathname, string aArgLine, string aWorkDir) {
      Execute(aEXEPathname, aArgLine, aWorkDir, true, true);
    }

    public static System.Diagnostics.Process Execute(string aEXEPathname, string aArgLine, string aWorkDir, bool aWait, bool aCapture) {
      var xStartInfo = new ProcessStartInfo();
      xStartInfo.FileName = aEXEPathname;
      xStartInfo.Arguments = aArgLine;
      xStartInfo.WorkingDirectory = aWorkDir;
      xStartInfo.CreateNoWindow = false;
      xStartInfo.UseShellExecute = !aCapture;
      xStartInfo.RedirectStandardError = aCapture;
      xStartInfo.RedirectStandardOutput = aCapture;
      var xProcess = System.Diagnostics.Process.Start(xStartInfo);
      Console.WriteLine();
      Console.WriteLine("Executing:");
      Console.WriteLine("  " + xStartInfo.FileName);
      Console.WriteLine("Arguments:");
      Console.WriteLine("  " + xStartInfo.Arguments);
      Console.WriteLine("Working Directory:");
      Console.WriteLine("  " + xStartInfo.WorkingDirectory);
      Console.WriteLine();

      if (!aWait && aCapture) {
        // we arent gonna wait till it has finished by default. 
        // but if there was an error the app may exit quickly and we should display it
        // wait a small amount of time then check
        Thread.Sleep(500);
      }

      if (aWait || (aCapture && xProcess.HasExited)) {
        if (!xProcess.WaitForExit(120 * 1000) || xProcess.ExitCode != 0) {
          //TODO: Fix
          if (aCapture) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error when executing: " + xStartInfo.FileName + " " +
                xStartInfo.Arguments + " from directory " + xStartInfo.WorkingDirectory);
            Console.Write(xProcess.StandardOutput.ReadToEnd());
            if (Environment.UserInteractive) {
              //System.Windows.Forms.MessageBox.Show(xProcess.StandardError.ReadToEnd());
            } else {
              Console.Write(xProcess.StandardError.ReadToEnd());
            }
            if (Environment.UserInteractive) {
              Console.WriteLine();
              Console.WriteLine("Press any key to continue");
              Console.ReadLine();
            } else {
              throw new Exception("Error while running program");
            }
          } else {
            throw new Exception("Call failed");
          }
        }
      }
      return xProcess;
    }
  }
}
