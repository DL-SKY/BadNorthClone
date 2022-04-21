using UnityEngine;

namespace DllSky.Components.Services
{
    public class DontDestroyComponent : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
