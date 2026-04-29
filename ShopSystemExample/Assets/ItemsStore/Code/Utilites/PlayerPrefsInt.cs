using UnityEngine;
using UnityEngine.Events;

namespace Assets.ItemsStore.Code.Utilites
{
    public class PlayerPrefsInt
    {
        private string _prefsKey;

        public UnityEvent<int, int> OnValueChanged = new();

        public PlayerPrefsInt(string prefsKey)
        {
            _prefsKey = prefsKey;
        }

        public int Value
        {
            get { return PlayerPrefs.GetInt(_prefsKey); }

            set
            {
                var oldValue = PlayerPrefs.GetInt(_prefsKey);
                PlayerPrefs.SetInt(_prefsKey, value);

                OnValueChanged?.Invoke(oldValue, value);
            }
        }
    }
}
