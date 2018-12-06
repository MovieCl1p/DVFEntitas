using UnityEngine;

namespace Unity
{
    public class ConveyerMono : MonoBehaviour
    {
        public float Velocity = 1;
        public float Length;
        public string Id;
        public string Next;

        public bool IsLoadInduct;
        public float InductRate = 3;
    }
}
