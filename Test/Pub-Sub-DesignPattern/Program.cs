using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub_Sub_DesignPattern
{
    /// <summary>
    /// https://www.youtube.com/watch?v=frGy-nGoGUY
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Publisher dogPublisher = new Publisher();
            Publisher catPublisher = new Publisher();

            Subscriber AnimalLover = new Subscriber();
            Subscriber OldCatLady = new Subscriber();

            PubSubServer Server = new PubSubServer();

            Message dogMessage = new Message();
            dogMessage.topic = "Dogs";
            dogMessage.payload = "Dogs are man's best friend";

            Message catMessage = new Message();
            catMessage.topic = "Cat";
            catMessage.payload = "Cats can take care of themservice";

            dogPublisher.Send(dogMessage, Server);
            catPublisher.Send(catMessage, Server);

            AnimalLover.Listen("Dogs", 0);
            AnimalLover.Listen("Cats", 1);

            OldCatLady.Listen("Cats", 0);

            Server.subscribers[0] = AnimalLover;
            Server.subscribers[1] = OldCatLady;

            Server.Forword();

            Console.WriteLine("AnimalLover has subscribed to the forwording message");
            AnimalLover.Print();

            Console.WriteLine("");

            Console.WriteLine("OldCatLady has subscribed to the forwording message");
            OldCatLady.Print();
        }
    }
}
