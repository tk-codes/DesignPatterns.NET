using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator
{
    public interface IParticipant
    {
        string GetName();
        void Send(string to, string message);
        void Receive(string from, string message);
    }

    public class Participant : IParticipant
    {
        private readonly string _name;
        private readonly IChatRoom _chatRoom;

        public Participant(string name, IChatRoom chatRoom)
        {
            this._name = name;
            this._chatRoom = chatRoom;

            this._chatRoom.RegisterParticipant(this);
        }

        public string GetName()
        {
            return this._name;
        }

        public void Send(string to, string message)
        {
            this._chatRoom.Send(this._name, to, message);
        }

        public void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: {2}", from, this._name, message);
        }
    }


}
