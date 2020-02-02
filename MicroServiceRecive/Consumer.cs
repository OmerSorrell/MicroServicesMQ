
/*
 * *****************************************
 * This is a 2 microservices data transfer using MassTransit on RabbitMQ,
 * Using Aes crypto for encryption.
 * Omer sorrell
 * PLEASE READ THE README FILE FOR FURTHER INSTRUCTIONS
 * *****************************************
 */


using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Messages;

namespace MicroServiceRecieve
{
    class Consumer : IConsumer<APIMessage>
    {
        public async Task Consume(ConsumeContext<APIMessage> context)
        {
            await Console.Out.WriteLineAsync($"Recieved: {context.Message.Name},{context.Message.Proffesion},{context.Message.DateTime}");
        }
    }
}
