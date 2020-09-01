using DataObjects;
using UnityEngine;
using UniRx;

namespace Main
{
    public class Storage : MonoBehaviour
    {
        public static GameData GameData;
        public static GeometryObjectData GeometryObjectData;

        private void Awake()
        {
            Resources.LoadAsync<GameData>("Data/ClicksColorDatas/GameData")
                .AsAsyncOperationObservable()
                .Subscribe(x => GameData = x.asset as GameData)
                .AddTo(this);

            Resources.LoadAsync<GeometryObjectData>("Data/ClicksColorDatas/GeometryObjectData")
                .AsAsyncOperationObservable()
                .Subscribe(x => GeometryObjectData = x.asset as GeometryObjectData)
                .AddTo(this);
        }
    }
}