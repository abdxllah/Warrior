﻿using UnityEngine;

namespace OpenAi.Unity
{
    /// <summary>
    /// Implementation of Singleton for <see cref="MonoBehaviour"/> that insures only a single instance
    /// of the <see cref="MonoBehaviour"/> exists in the scene, and that instance is not destroyed
    /// between scene loads
    /// </summary>
    /// <typeparam name="T">The type of the subclass.</typeparam>
    public abstract class AMonoSingleton<T> : MonoBehaviour
        where T : AMonoSingleton<T>
    {
        private static T _instance;

        private static bool _instantiating = false;

        private static bool AppQuitting { get; set; } = false;

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static T Instance
        {
            get
            {
                if (AppQuitting)
                {
                    Debug.LogWarning($"No {nameof(AMonoSingleton<T>)} returned because application is quiting");
                    return null;
                }
                TryCreateSingleton(_instance, ref _instance);
                return _instance;
            }
        }

        /// <summary>
        /// <para>Tries to create a singleton. Succeeds if no instance has yet been created. Destroys any calling object that isn't the instance</para>
        /// </summary>
        /// <param name="caller">The instance calling the function</param>
        /// <param name="instanceVar">A reference to the variable which holds the instance</param>
        /// <returns>false if trying to create new instance</returns>
        public static bool TryCreateSingleton(T caller, ref T instanceVar)
        {
            // if no instance created, can create
            if (instanceVar == null)
            {
                // block used to catch other threads creating singleton
                if (_instantiating)
                {
                    //Debug.LogWarning("Attempting to instantiate singleton, but _instantiation attempts indicate another thread is instantiating");
                    return false;
                }
                _instantiating = true;

                // Check if there is a gameobject in the scene using the monobehaviour.
                // If not make one
                instanceVar = FindObjectOfType<T>();
                if (instanceVar == null)
                {
                    instanceVar = new GameObject(typeof(T).Name + "(AutoGenerated)").AddComponent<T>();
                }

                // Mark Singleton not to be destroyed between scenes. DontDestroyOnLoad only works for root level objects
                if (instanceVar.transform.parent != null) instanceVar.transform.SetParent(null);
                DontDestroyOnLoad(instanceVar.gameObject);

                return true;
            }
            else if (caller != instanceVar)
            {
                Destroy(caller);
                return false;
            }
            return true;
        }


        private void OnApplicationQuit() => AppQuitting = true;

        protected void Awake() => TryCreateSingleton((T)this, ref _instance);
    }
}