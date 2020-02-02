
/*
 * *****************************************
 * This is a 2 microservices data transfer using MassTransit on RabbitMQ,
 * Using Aes crypto for encryption.
 * Omer sorrell
 * PLEASE READ THE README FILE FOR FURTHER INSTRUCTIONS
 * *****************************************
 */


using System;
using System.Text;
using MassTransit;
using Messages;
using MicroServiceSend;

namespace MicroServiceClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //Encryped by generating random AesCrypto byteArray.
            byte[] key =  { 196, 115, 47, 224, 40, 137, 221, 142, 2, 156, 230, 12, 229, 90, 241, 12, 232, 114, 96, 143, 72, 66, 191, 146, 69, 40, 197, 206, 42, 33, 135, 100 };

            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var queueHost = sbc.Host(new Uri("rabbitmq://localhost"), host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });

                sbc.UseEncryption(key);

            });

            bus.Start();

            Message message = new Message();
            message = message.getMessage(message);

            // Remove the age by changing the object type to APIMessage
            await bus.Publish(message.ToApiObject());
            Console.ReadKey();

            bus.Stop();
        }

    }
}
