using UnityEngine;

namespace DataObjects
{
    [CreateAssetMenu(fileName = "New ClicksColorData", menuName = "ClicksColorData", order = 51)]
    public class ClicksColorData : ScriptableObject
    {
        public string ObjectType;

        public int MinClicksCount;
        public int MaxClicksCount;

        public Color Color;
    }
}