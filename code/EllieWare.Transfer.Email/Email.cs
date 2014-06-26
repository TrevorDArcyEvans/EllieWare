//
//  Copyright (C) 2013 EllieWare
//
//  All rights reserved
//
//  www.EllieWare.com
//
using System.Threading;
using EllieWare.Common;
using EllieWare.Interfaces;

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

    private void SendMailPopup()
    {
      var mapi = mControl.GetEmail();

      mapi.SendMailPopup(mControl.mSubject.ResolvedValue, mControl.mMessage.ResolvedValue);
    }

    public bool Run()
    {
#if false
      var mapi = mControl.GetEmail();
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
