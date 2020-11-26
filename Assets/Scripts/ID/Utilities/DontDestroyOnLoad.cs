using UnityEngine;

namespace ID.Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
    } 
}

