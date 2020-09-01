using UnityEngine;

namespace Main
{
    public class ClickHandler : MonoBehaviour
    {
        private void Awake()
        {
            _objectsSpawner = new ObjectsSpawner(OnObjectSpawnerIntitialized);
        }

        private void Raycaster_OnPlanePositionGet(Vector3 pos)
        {
            _objectsSpawner.RandomSpawn(pos);
        }

        private void Raycaster_OnColliderGet(GameObject obj)
        {
            obj.GetComponent<GeometryObjectModel>().OnClick();
        }

        private void OnObjectSpawnerIntitialized()
        {
            Raycaster.OnColliderGet += Raycaster_OnColliderGet;
            Raycaster.OnPlanePositionGet += Raycaster_OnPlanePositionGet;
        }

        private ObjectsSpawner _objectsSpawner;
    }
}