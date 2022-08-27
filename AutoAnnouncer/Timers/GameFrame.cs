using System;
using System.Collections.Generic;
using System.Text;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace Notify.AutoAnnouncer.Timers
{
    internal class GameFrame : MonoBehaviour
    {
        private static GameFrame _instance;

        public delegate void GameFrameUpdateEventHandler();

        /// <summary>
        /// Event emitted every frame update
        /// </summary>
        public static event GameFrameUpdateEventHandler OnUpdate;

        /// <summary>
        /// Event emitted every frame late update
        /// </summary>
        public static event GameFrameUpdateEventHandler OnLateUpdate;

        void Update()
        {
            try
            {
                OnUpdate?.Invoke();
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError("Error dispatching OnUpdate event:");
                Plugin.Logger.LogError(ex);
            }
        }

        void LateUpdate()
        {
            try
            {
                OnLateUpdate?.Invoke();
            }
            catch (Exception ex)
            {
                Plugin.Logger.LogError("Error dispatching OnLateUpdate event:");
                Plugin.Logger.LogError(ex);
            }
        }

        public static void Initialize()
        {
            if (!ClassInjector.IsTypeRegisteredInIl2Cpp<GameFrame>())
            {
                ClassInjector.RegisterTypeInIl2Cpp<GameFrame>();
            }

            _instance = Plugin.Instance.AddComponent<GameFrame>();
        }

        public static void Uninitialize()
        {
            OnUpdate = null;
            OnLateUpdate = null;
            Destroy(_instance);
            _instance = null;
        }

    }
}
