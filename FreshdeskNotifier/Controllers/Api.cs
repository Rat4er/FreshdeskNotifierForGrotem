using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreshdeskNotifier.Model;
using FreshdeskNotifier.Logs;
using Microsoft.Extensions.Logging;

namespace FreshdeskNotifier.Controllers
{
    [ApiController]
    public class Api : ControllerBase
    {
        [HttpPost]
        [Route("/telegram")]
        public void TelegramSender(RootObject FreshdeskJSON)
        {
            try
            {
                TelegramWorker tlg = new TelegramWorker();
                tlg.SendMessage(FreshdeskJSON);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
            }
        }
    }
}
