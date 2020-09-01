using Newtonsoft.Json;
using UnityEngine;

namespace DataObjects
{
    public class SmartPath
    {
        [JsonIgnore]
        public string GlobalPath => $"{ Application.dataPath}/{LocalPath}";

        public string LocalPath;
        public string PrefabName;
    }
}