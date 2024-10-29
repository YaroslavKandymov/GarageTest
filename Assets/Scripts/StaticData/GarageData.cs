using DG.Tweening;
using UnityEngine;

namespace Garage.StaticData
{
    [CreateAssetMenu(fileName = "new GarageData", menuName = "StaticData/GarageData", order = 1)]
    public class GarageData : ScriptableObject
    {
        [SerializeField] private Vector3 _doorOffset;
        [SerializeField] private float _moveTime;
        [SerializeField] private Ease _ease;

        public Vector3 DoorOffset => _doorOffset;
        public float MoveTime => _moveTime;
        public Ease Ease => _ease;
    }
}