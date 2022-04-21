using System;
using System.Collections.Generic;
using UnityEngine;

namespace DllSky.Services
{
    public static class ComponentLocator
    {
        public static event Action<Type> OnRegistered;
        public static event Action<Type> OnUnregistered;

        private static readonly Dictionary<Type, Component> _components = new Dictionary<Type, Component>();


        public static void Register<T>(T component) where T : Component
        {
            var type = component.GetType();
            if (_components.ContainsKey(type))
                _components[type] = component;
            else
                _components.Add(type, component);

            OnRegistered?.Invoke(type);

            Debug.Log($"[ComponentLocator] Register \"{type}\"");
        }

        public static void Unregister<T>() where T : Component
        {
            var type = typeof(T);
            Unregister(type);
        }

        public static void Unregister(Type type)
        {
            _components.Remove(type);

            OnUnregistered?.Invoke(type);

            Debug.Log($"[ComponentLocator] Unregister \"{type}\"");
        }

        public static T Resolve<T>() where T : Component
        {
            var type = typeof(T);

            if (_components.ContainsKey(type))
                return (T)_components[type];

            return default;
        }

        public static void Clear()
        {
            _components.Clear();
        }
    }
}
