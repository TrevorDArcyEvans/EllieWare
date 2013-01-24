using System;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;

namespace CrashReporterDotNET
{
  public class ReportCrash
  {
    public String ToEmail;

    public void Send(Exception exception)
    {
      try
      {
        var captureScreenshot = new CaptureScreenshot();
        captureScreenshot.CaptureScreenToFile(string.Format("{0}\\{1}CrashScreenshot.png", Path.GetTempPath(), System.Reflection.Assembly.GetEntryAssembly().GetName().Name), ImageFormat.Png);
      }
      catch
      {
      }
      if (String.IsNullOrEmpty(ToEmail))
      {
        return;
      }
      var toAddress = new MailAddress(ToEmail);

      var crashReport = new CrashReport(exception, toAddress);

      crashReport.ShowDialog();
    }
  }
}
