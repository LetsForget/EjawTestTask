using System.Collections.Generic;
using UnityEngine;

namespace DataObjects
{
    [CreateAssetMenu(fileName = "New GeometryObjectData", menuName = "GeometryObjectData", order = 52)]
    public class GeometryObjectData : ScriptableObject
    {
        public List<ClicksColorData> ClicksData;
    }
}