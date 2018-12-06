using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class RatDestinationPoint
    {
        public Vector3 Position;
        public string RoutingCode;
        public bool InBound;
        public string Next;

        public RatDestinationPoint(Vector3 position, string routingCode, bool inBound, string next)
        {
            Position = position;
            RoutingCode = routingCode;
            InBound = inBound;
            Next = next;
        }
    }
}
