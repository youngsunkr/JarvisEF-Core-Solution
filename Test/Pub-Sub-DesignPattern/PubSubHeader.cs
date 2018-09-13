using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub_Sub_DesignPattern
{
    class Publisher
    {
        public Publisher()
        {
        }

        public void Send(Message newMessage, PubSubServer myServer)
        {
            myServer.buffer.Enqueue(newMessage);
        }
    }

    
    class Subscriber
    {
        public Subscriber()
        {
        }

        public string[] topics = new string[2];
        public Queue<Message> myMessages = new Queue<Message>();
        public void Listen(string newTopic, int index)
        {
            topics[index] = newTopic;
        }

        public void Print()
        {
            for (int i = 0; i < topics.Length; i++)
            {
                Message newMessage = myMessages.Dequeue();
                Console.WriteLine("Topics: " + newMessage.topic + "\n" + newMessage.payload);
            }
        }
    }

    class Message
    {
        public Message()
        {
        }

        public string payload;
        public string topic;
    }


    class PubSubServer
    {
        public PubSubServer()
        {
        }

        public Queue<Message> buffer = new Queue<Message>();
        public Subscriber[] subscribers = new Subscriber[2];

        public void Forword()
        {
            while (buffer.Count != 0)
            {
                Message tempMessage = buffer.Dequeue();
                for (int i = 0; i < subscribers.Length; i++)
                {
                    for (int j = 0; j < subscribers[i].topics.Length; j++)
                    {
                        if (tempMessage.topic == subscribers[i].topics[j])
                        {
                            subscribers[i].myMessages.Enqueue(tempMessage);
                        }
                    }
                }
            }
        }
    }
}
