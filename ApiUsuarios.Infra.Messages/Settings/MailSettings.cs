using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Messages.Settings
{
    public class MailSettings
    {
        public static string? Account => "cotiaulajava@outlook.com";
        public static string? Password => "@Admin123456";
        public static string? Smtp => "smtp-mail.outlook.com";
        public static int? Port => 587;
    }
}
