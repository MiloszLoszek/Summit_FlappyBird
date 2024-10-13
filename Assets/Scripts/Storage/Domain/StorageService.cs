using Functional.Maybe;

namespace Tripledot.FlappyBird.Leaderboard
{
    public interface StorageService
    {
        Maybe<string> Get(string id);
        void Save(string key, string data);
    }
}