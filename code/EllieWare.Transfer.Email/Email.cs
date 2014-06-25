//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EllieWare.Common;
using EllieWare.Interfaces;
using SendFileTo;

namespace EllieWare.Transfer.Email
{
  public class Email : MutableRunnableBase<EmailCtrl>
  {
    public Email()
    {
    }

    public Email(IRobotWare root, ICallback callback, IParameterManager mgr) :
      base(root, callback, mgr)
    {
    }

    public override string Summary
    {
      get
      {
        var summ = string.Format("Send email to {0} about {1} with {2} attachments",
                      GetAllRecipients().Count(),
                      mControl.mSubject.ResolvedValue,
                      GetAllAttachments().Count());

        return summ;
      }
    }

    private IEnumerable<string> GetAllRecipients()
    {
      return mControl.mRecipients.ResolvedValue.Split(new[] { ';' }).Where(x => !string.IsNullOrEmpty(x));
    }

    private IEnumerable<string> GetAllAttachments()
    {
      return mControl.mAttachments.ResolvedValue.Split(new[] { ';' }).Where(x => !string.IsNullOrEmpty(x));
    }

    private MAPI GetEmail()
    {
      var mapi = new MAPI();

      var allRecipients = GetAllRecipients();
      foreach (var thisRecipient in allRecipients)
      {
        mapi.AddRecipientTo(thisRecipient.Trim());
      }

      var allAttachments = GetAllAttachments();
      foreach (var thisAttachment in allAttachments)
      {
        mapi.AddAttachment(thisAttachment.Trim());
      }
      return mapi;
    }

    private void SendMailPopup()
    {
      var mapi = GetEmail();

      mapi.SendMailPopup(mControl.mSubject.ResolvedValue, mControl.mMessage.ResolvedValue);
    }

    public override bool Run()
    {
#if false
      var mapi = GetEmail();
#endif

      var retVal = true;

#if false
      // Try and do a direct send without displaying the mail dialog
      // but Outlook will display a warning about program trying to send spam
      retVal = 0 == mapi.SendMailDirect(mSubject.ResolvedValue, mMessage.ResolvedValue);
#endif

#if false
      // This will display a blocking dialog
      retVal = 0 == mapi.SendMailPopup(mSubject.ResolvedValue, mMessage.ResolvedValue);
#endif

      // Or we can display the blocking dialog in a separate thread
      var thread = new Thread(SendMailPopup);
      thread.SetApartmentState(ApartmentState.STA);
      thread.Start();

      return retVal;
    }
  }
}
