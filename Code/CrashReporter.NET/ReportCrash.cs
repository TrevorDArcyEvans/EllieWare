using System;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace CrashReporterDotNET
{
  public class ReportCrash
  {
    public String FromEmail;

    public String ToEmail;

    public String SMTPHost;

    public int Port = 25;

    public Boolean EnableSSL;

    public String UserName = "";

    public String Password = "";

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
      if (String.IsNullOrEmpty(FromEmail) || String.IsNullOrEmpty(ToEmail) || String.IsNullOrEmpty(SMTPHost))
      {
        return;
      }
      var fromAddress = new MailAddress(FromEmail);
      var toAddress = new MailAddress(ToEmail);

      var smtp = new SmtpClient
      {
        Host = SMTPHost,
        Port = Port,
        EnableSsl = EnableSSL,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(UserName, Password),
      };

      var crashReport = new CrashReport(exception, fromAddress, toAddress, smtp);

      crashReport.ShowDialog();
    }
  }
}
