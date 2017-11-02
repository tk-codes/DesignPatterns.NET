using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralPatterns.Mediator
{
    public interface IChatRoom
    {
        void RegisterParticipant(IParticipant participant);
        void Send(String from, String to, string message);
    }

    public class ChatRoom : IChatRoom
    {

        private readonly IDictionary<string, IParticipant> _participants = new Dictionary<string, IParticipant>();

        public void RegisterParticipant(IParticipant participant)
        {
            this._participants.Add(participant.GetName(), participant);
        }

        public void Send(string from, string to, string message)
        {
            if (this._participants.ContainsKey(to))
            {
                this._participants[to].Receive(from, message);
            }
            else
            {
                throw new ArgumentException("{0} not found", to);
            }
        }
    }
}
