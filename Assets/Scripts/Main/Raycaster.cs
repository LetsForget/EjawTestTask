using System;
using UniRx;
using UnityEngine;

namespace Main
{
    public class Raycaster : MonoBehaviour
    {
        public static event Action<GameObject> OnColliderGet;
        public static event Action<Vector3> OnPlanePositionGet;

        private void Start()
        {
            _plane = new Plane(_planeNormal, _planePos);

            Observable.EveryUpdate()
                .Where(_ => Input.GetKeyDown(KeyCode.Mouse0))
                .Subscribe(x =>
                {
                    OnMouseButtonPressed();
                })
                .AddTo(this);
        }

        private void OnMouseButtonPressed()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out RaycastHit hit, 100))
            {
                OnColliderGet?.Invoke(hit.collider.gameObject);
                return;
            }
            else if (_plane.Raycast(ray, out float enter))
            {
                Vector3 pos = ray.GetPoint(enter);
                OnPlanePositionGet?.Invoke(pos);
            }
        }

        private Plane _plane;

        [SerializeField] private Vector3 _planePos;
        [SerializeField] private Vector3 _planeNormal;
    }
}