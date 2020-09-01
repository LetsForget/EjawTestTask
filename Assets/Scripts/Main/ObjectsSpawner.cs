using DataObjects;
using UnityEngine;
using UniRx;
using System;
using Newtonsoft.Json;
using Downloading;
using System.Linq;

namespace Main
{
    public class ObjectsSpawner
    {
        public ObjectsSpawner(Action onInitialized)
        {
            Resources.LoadAsync<TextAsset>("Data/geometry_models")
                .AsAsyncOperationObservable()
                .Subscribe(x =>
                {
                    if (x != null)
                    {
                        string bundlesInfoStr = (x.asset as TextAsset).text;

                        _bundlesInfo = JsonConvert.DeserializeObject<BundlesInfo>(bundlesInfoStr);
                        _bundlesCount = _bundlesInfo.Count;

                        onInitialized();
                    }
                });           
        }


        public void RandomSpawn(Vector3 pos)
        {
            int randomElem = UnityEngine.Random.Range(0, _bundlesCount);
            Spawn(_bundlesInfo.Keys.ElementAt(randomElem), pos);
        }

        public void Spawn(string objectType, Vector3 pos)
        {
            if (_bundlesInfo.TryGetValue(objectType, out SmartPath path))
            {
                BundleDownloader.Download(path.GlobalPath,
                    x =>
                    {
                        HandleAssetBundle(x, path.PrefabName, abr => InstanitiateAtPos(abr.asset as GameObject, pos));
                    });
            }
        }

        private void HandleAssetBundle(AssetBundle bundle, string assetName, Action<AssetBundleRequest> onLoaded)
        {
            bundle.LoadAssetAsync(assetName)
                .AsAsyncOperationObservable()
                .Subscribe(x =>
                {
                    onLoaded(x);
                });
        }

        private void InstanitiateAtPos(GameObject g, Vector3 pos)
        {
            GameObject.Instantiate(g).transform.position = pos;
        }

        private BundlesInfo _bundlesInfo;
        private int _bundlesCount;
    }
}