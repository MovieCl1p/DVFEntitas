using System;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Unity
{
    [Serializable]
    public class DestinationPointMono
    {
        public Transform point;
        public string RoutingCode;
        public bool InBound;
        public string Next;
    }

    public class RatMono : MonoBehaviour
    {
        public List<DestinationPointMono> Points;

        public List<RatDestinationPoint> GetDestinationPoints()
        {
            List<RatDestinationPoint> result = new List<RatDestinationPoint>();
            for (int i = 0; i < Points.Count; i++)
            {
                var point = Points[i];
                RatDestinationPoint p = new RatDestinationPoint(point.point.position, point.RoutingCode, point.InBound, point.Next);
                result.Add(p);
            }

            return result;
        }
    }
}
