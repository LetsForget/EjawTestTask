using DataObjects;
using UniRx;
using UnityEngine;

namespace Main
{
    public class GeometryObjectModel : MonoBehaviour
    {
        
        private void Start()
        {
            Observable.Timer(System.TimeSpan.FromSeconds(Storage.GameData.ObservableTime))
                .Repeat()
                .Subscribe(_ =>
                {
                    SetRandomColor();
                });
        }

        private void SetRandomColor()
        {
            Color color = Random.ColorHSV();
            SetColor(color);
        }

        private void SetColor(Color color)
        {
            _meshRenderer.material.color = color;
        }

        public void OnClick()
        {
            _clickCount++;

            foreach(ClicksColorData clicksData in Storage.GeometryObjectData.ClicksData)
            {
                if (clicksData.ObjectType == _objectType)
                {
                    if (_clickCount >= clicksData.MinClicksCount && _clickCount <= clicksData.MaxClicksCount)
                    {
                        SetColor(clicksData.Color);
                        return;
                    }
                }
            }
        }

        private int _clickCount = 0;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private string _objectType;
    }
}