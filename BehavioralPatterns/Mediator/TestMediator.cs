using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator
{
    public class TestMediator
    {
        public static void Run()
        {
            IChatRoom chatRoom = new ChatRoom();

            IParticipant einstein = new Participant("Einstein", chatRoom);
            IParticipant newton = new Participant("Newton", chatRoom);
            IParticipant galileo = new Participant("Galileo", chatRoom);

            newton.Send(galileo.GetName(), "I discoverd laws of motion");
            einstein.Send(newton.GetName(), "I discovered how gravity works");

            Console.ReadKey();
        }
    }
}
