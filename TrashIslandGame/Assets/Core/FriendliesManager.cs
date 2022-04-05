using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class FriendliesManager : MonoBehaviour
    {
        public List<Friendly> friendlies;

        public void Add(Friendly friendly)
        {
            friendlies.Add(friendly);
        }
        public void Remove(Friendly friendly)
        {
            if (friendlies.Contains(friendly))
            {
                friendlies.Remove(friendly);
            }
        }
    }
}
