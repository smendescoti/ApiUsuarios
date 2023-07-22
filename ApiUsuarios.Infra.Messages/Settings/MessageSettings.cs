using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuarios.Infra.Messages.Settings
{
    /// <summary>
    /// Classe para definir os parametros de conexão
    /// com o servidor da fila (RabbitMQ)
    /// </summary>
    public class MessageSettings
    {
        /// <summary>
        /// URL para conexão com o servidor do RabbitMQ
        /// </summary>
        public static string Url
            => "amqps://xhkngehj:rjBBlPRtvMwA_WMmBxdJJFgpcxEOzCDV@chimpanzee.rmq.cloudamqp.com/xhkngehj";

        /// <summary>
        /// Nome da fila que iremos acessar no servidor
        /// </summary>
        public static string QueueName
            => "mensagens_usuarios";
    }
}
