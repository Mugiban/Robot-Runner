using UnityEngine;

namespace ID.Utilities
{

    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        _instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
        }
    }

}