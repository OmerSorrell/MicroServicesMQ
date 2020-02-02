
/*
 * *****************************************
 * This is a 2 microservices data transfer using MassTransit on RabbitMQ,
 * Using Aes crypto for encryption.
 * Omer sorrell
 * PLEASE READ THE README FILE FOR FURTHER INSTRUCTIONS
 * *****************************************
 */


using Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceSend
{
    public class Message
    {
        private String name;
        private int age;
        private DateTime dateTime;
        private String proffesion;


        public Message(String name, int age, DateTime dateTime, String proffesion)
        {
            this.Name = name;
            this.Age = age;
            this.Proffesion = proffesion;
            this.DateTime = dateTime;
        }

        public Message()
        {

        }

        public string Name { get => name; set => name = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string Proffesion { get => proffesion; set => proffesion = value; }
        public int Age { get => age; set => age = value; }


        internal APIMessage ToApiObject() => new APIMessage(name, dateTime, proffesion);


        public Message getMessage(Message message)
        {
            Console.WriteLine("Enter The message you want to send (Name, Age, Proffesion)");
            String temp = Console.ReadLine();
            String[] userMessage = temp.Split(',');
            message = new Message(userMessage[0], Int16.Parse(userMessage[1]), DateTime.Now, userMessage[2]);
            return message;
        }

    }
}
