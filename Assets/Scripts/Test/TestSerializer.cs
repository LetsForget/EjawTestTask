using DataObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace Test
{
    public class TestSerializer : MonoBehaviour
    {
        private void Start()
        {
            BundlesInfo bundleInfo = new BundlesInfo
            {
                { "Cube", new SmartPath() { LocalPath = "Bundles/cube_geometry_model", PrefabName = "Cube" } },
                { "Sphere", new SmartPath() { LocalPath = "Bundles/sphere_geometry_model", PrefabName = "Sphere" } },
                { "Capsule", new SmartPath() { LocalPath = "Bundles/capsule_geometry_model", PrefabName = "Capsule" } }
            };

            string jsonStr = JsonConvert.SerializeObject(bundleInfo);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonStr);

            try
            {
                FileStream fs = new FileStream("geometry_models.json", FileMode.Create);
                fs.Write(jsonBytes, 0, jsonBytes.Length);
            }
            catch(Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}