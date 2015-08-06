using System.Collections.Concurrent;
using System.Collections.Generic;
using Demos.Data;

namespace Demos.Services
{
    public class InMemorySessionService : IConferenceSessionService
    {
        protected static ConcurrentDictionary<int, ConferenceSession> Sessions { get; private set; }

        static InMemorySessionService()
        {          
            Sessions = new ConcurrentDictionary<int, ConferenceSession>();
            Sessions.TryAdd(1, new ConferenceSession
            {
                Name = "Real World Web Perf",
                Presenter = "Nik Molnar",
                Room = "Cloud & Web"
            });

            Sessions.TryAdd(2, new ConferenceSession
            {
                Name = ".Net and Neo4j",
                Presenter = "Greg Jordan",
                Room = "Services & Data"
            });

            Sessions.TryAdd(3, new ConferenceSession
            {
                Name = "iOS Apps with Swift",
                Presenter = "Nik Molnar",
                Room = "Michael Crump"
            });
        }

        public virtual IEnumerable<ConferenceSession> GetSessions()
        {
            return Sessions.Values;
        }

        public  virtual  void AddSession(ConferenceSession session)
        {
            Sessions.TryAdd(Sessions.Count + 1, session);
        }
    }

    public interface IConferenceSessionService
    {
        IEnumerable<ConferenceSession> GetSessions();
        void AddSession(ConferenceSession session);
    }
}
