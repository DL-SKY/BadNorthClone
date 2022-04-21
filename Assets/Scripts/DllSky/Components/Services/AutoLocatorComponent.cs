using DllSky.Services;
using System;
using UnityEngine;

namespace DllSky.Components.Services
{
    public class AutoLocatorComponent : MonoBehaviour
    {
        [HideInInspector, SerializeField] protected bool _isDontDestroy = true;
        [HideInInspector, SerializeField] private bool _isRegisterCurrentComponent = true;
        [HideInInspector, SerializeField] protected Component _component;
        private Type _type;


        protected void Awake()
        {
            if (_isDontDestroy)
                TryApplyDontDestroy();

            if (_component == null)
                _component = this;

            _type = _component.GetType();
            ComponentLocator.Register(_component);

            CustomAwake();
        }

        protected void OnDestroy()
        {
            ComponentLocator.Unregister(_type);

            CustomOnDestroy();
        }


        protected virtual void CustomAwake() { }
        protected virtual void CustomOnDestroy() { }


        private void TryApplyDontDestroy()
        {
            if (transform.parent == null)
                DontDestroyOnLoad(gameObject);
            else
                Debug.LogWarning($"[AutoLocatorObject] TryApplyDontDestroy() => Object \"{name}\" not root GameObject!");
        }
    }
}
