using System.Collections.Generic;
using UnityEngine;

namespace DataObjects
{
    [CreateAssetMenu(fileName = "New GameData", menuName = "GameData", order = 53)]
    public class GameData : ScriptableObject
    {
        public int ObservableTime;
    }
}