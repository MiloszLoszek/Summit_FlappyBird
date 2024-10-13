using Functional.Maybe;
using Tripledot.FlappyBird.Leaderboard;
using UnityEngine;

namespace Tripledot.FlappyBird.Leaderboard.Infrastructure.Services
{
    public class PlayerPrefsStorageService : StorageService
    {
        public Maybe<string> Get(string id)
        {
            var value = PlayerPrefs.GetString(id, string.Empty);

            return string.IsNullOrEmpty(value) 
                ? Maybe<string>.Nothing 
                : value.ToMaybe();
        }

        public void Save(string key, string data) => PlayerPrefs.SetString(key, data);
    }
}
