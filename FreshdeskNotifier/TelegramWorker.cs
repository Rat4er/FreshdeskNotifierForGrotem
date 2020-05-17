using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MihaZupan;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using FreshdeskNotifier.Model;
using FreshdeskNotifier.Logs;

namespace FreshdeskNotifier
{
    public class TelegramWorker
    {
        private TelegramBotClient TelegramBot
        {
            //На данный момент, в качестве прокси используется TOR сеть. Можно не использовать, если хоститься будет не в России
            get { return new TelegramBotClient("insert telegramBot API key here", new HttpToSocks5Proxy("127.0.0.1", 9150)); }
        }

        public async void SendMessage(RootObject root)
        {
            try
            {
                string message = MessageTextCreator(root);
                
                TelegramBotClient bot = this.TelegramBot;
                await bot.SendTextMessageAsync(
                    chatId: "insert telegram chatId here",
                    text: message);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex.ToString());
            }

        }

        private string MessageTextCreator(RootObject root)
        {       
            string message = $"Был обновлен тикет!\nid тикета - {root.freshdesk_webhook.ticket_id}\nСсылка на тикет - {root.freshdesk_webhook.ticket_url}\nСтатус - {root.freshdesk_webhook.ticket_status}\nТема - {root.freshdesk_webhook.ticket_subject}";
            return message;
        }
    }
}
