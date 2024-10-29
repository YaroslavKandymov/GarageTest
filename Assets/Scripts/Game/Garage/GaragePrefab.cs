using UnityEngine;

namespace Garage.Game.Garage
{
    public class GaragePrefab : MonoBehaviour
    {
        [SerializeField] private GameObject _door;

        public GameObject Door => _door;
    }
}