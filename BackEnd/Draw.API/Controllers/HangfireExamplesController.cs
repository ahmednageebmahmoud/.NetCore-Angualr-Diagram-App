using Draw.BLL.HangfireBLL;
using Microsoft.AspNetCore.Mvc;

namespace Draw.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HangfireExamplesController : Controller
    {
        private readonly IHangfireService hang;

        public HangfireExamplesController(IHangfireService hang)
        {
            this.hang = hang;
        }

        /// <summary>
        ///  (Enqueue Job) Call Job Immediately, Call For Fisrt Itme Only 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpGet("EnqueueJob")]
        public IActionResult EnqueueJob(string message)
        {
            this.hang.SendMail(message);
            return Json("Success");
        }



        /// <summary>
        /// Scheduled Job, Call Job After Some Seconds, Call For Fisrt Itme Only
        /// </summary>
        /// <param name="message"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [HttpGet("ScheduledJob")]
        public IActionResult ScheduledJob(string message,int seconds)
        {
            this.hang.SendMail(message, seconds);
            return Json("Success");
        }

        /// <summary>
        /// (Recurring Job), Call Job After Period Starting , Call For Every Period
        /// </summary>
        /// <param name="message"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [HttpGet("ScheduledJob")]
        public IActionResult RecurringJob(string message)
        {
            this.hang.SendMail(message, true);
            return Json("Success");
        }

    }
}
