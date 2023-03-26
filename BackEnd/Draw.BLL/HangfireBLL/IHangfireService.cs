using Hangfire.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.HangfireBLL
{
    public interface IHangfireService
    {
        /// <summary>
        ///  (Enqueue Job) Call Job Immediately, Call For Fisrt Itme Only 
        /// </summary>
        /// <param name="message"></param>
        void SendMail(string message);


        /// <summary>
        /// (Scheduled Job) Call Job After Some Seconds, Call For Fisrt Itme Only 
        /// </summary>
        /// <param name="message"></param>
        void SendMail(string message,int seconds);




        /// <summary>
        /// (Recurring Job), Call Job After Period Starting , Call For Every Period
        /// </summary>
        /// <param name="message"></param>
        void SendMail(string message, bool isRcurring);
        
    }
}
