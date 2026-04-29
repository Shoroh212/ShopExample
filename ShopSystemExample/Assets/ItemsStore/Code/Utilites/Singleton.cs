using UnityEngine;

namespace ItemStore.Code.Utility
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance => GetInstance();

        private static T GetInstance()
        {
            _instance ??= FindAnyObjectByType<T>(FindObjectsInactive.Exclude);
            return _instance;
        }
    }
}
