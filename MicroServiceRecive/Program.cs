
/*
 * *****************************************
 * This is a 2 microservices data transfer using MassTransit on RabbitMQ,
 * Using Aes crypto for encryption.
 * Omer sorrell
 * PLEASE READ THE README FILE FOR FURTHER INSTRUCTIONS
 * *****************************************
 */


using System;
using MassTransit;
using MicroServiceRecieve;

namespace MicroServiceClient
{
    class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {
            //Encryped by generating random AesCrypto byteArray.
            byte[] key = { 196, 115, 47, 224, 40, 137, 221, 142, 2, 156, 230, 12, 229, 90, 241, 12, 232, 114, 96, 143, 72, 66, 191, 146, 69, 40, 197, 206, 42, 33, 135, 100 };

            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var queueHost = sbc.Host(new Uri("rabbitmq://localhost"), host =>
                {
                    host.Username("guest");
                    host.Password("guest");
                });

                sbc.ClearMessageDeserializers();
                sbc.UseEncryption(key);

                sbc.ReceiveEndpoint(queueHost, "newQueue", ep =>
                {
                    ep.Consumer<Consumer>();
                });

            });

            bus.Start();

            Console.ReadKey();

            bus.Stop();
        }
    }
}
