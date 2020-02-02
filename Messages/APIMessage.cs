
/*
 * *****************************************
 * This is a 2 microservices data transfer using MassTransit on RabbitMQ,
 * Using Aes crypto for encryption.
 * Omer sorrell
 * PLEASE READ THE README FILE FOR FURTHER INSTRUCTIONS
 * *****************************************
 */


using System;
using System.Collections.Generic;
using System.Text;

namespace Messages
{
    public class APIMessage
    {
        private String name;
        private DateTime dateTime;
        private String proffesion;


        public APIMessage(String name, DateTime dateTime, String proffesion)
        {
            this.Name = name;
            this.Proffesion = proffesion;
            this.DateTime = dateTime;
        }

        public string Name { get => name; set => name = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string Proffesion { get => proffesion; set => proffesion = value; }

    }
}
