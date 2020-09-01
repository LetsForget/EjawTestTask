using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Downloading
{
    public static class BundleDownloader
    {
        public static void Download(string localPath, Action<AssetBundle> onLoaded)
        {
            if (_downloadedBundles.TryGetValue(localPath, out AssetBundle assetBundle))
            {
                onLoaded(assetBundle);
                return;
            }
            else
            {
                AssetBundle.LoadFromFileAsync(localPath)
                    .AsAsyncOperationObservable()
                    .Subscribe(x =>
                        {
                            _downloadedBundles.Add(localPath, x.assetBundle);
                            onLoaded(x.assetBundle);
                        });
            }
        }

        private static Dictionary<string, AssetBundle> _downloadedBundles = new Dictionary<string, AssetBundle>();
    }
}