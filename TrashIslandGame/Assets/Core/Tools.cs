using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public static class Tools
    {
        public static void SetAllInactive(List<GameObject> list)
        {
            foreach (var i in list)
            {
                i.SetActive(false);
            }
        }
    }
}