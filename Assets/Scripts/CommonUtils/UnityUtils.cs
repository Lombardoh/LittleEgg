using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameUtils
{
    public static class UnityUtils
    {
        public static T GetOrAddComponent<T>(GameObject obj) where T : Component
        {
            T component;
            if (!obj.TryGetComponent<T>(out component))
            {
                component = obj.AddComponent<T>();
            }
            return component;
        }
        public static void UpdateStatusUI(List<TextMeshPro> containers, List<string> newText)
        {
            for (int i = 0; i < containers.Count; i++) 
            {
                containers[i].text = newText[i];
            }
        }
    }
}
