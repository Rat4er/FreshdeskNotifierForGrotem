using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreshdeskNotifier.Model
{
    public class FreshdeskWebhook
    {
        public int ticket_id { get; set; }
        public string ticket_subject { get; set; }
        public string ticket_description { get; set; }
        public string ticket_url { get; set; }
        public string ticket_latest_public_comment { get; set; }
        public string ticket_status { get; set; }
    }
}
