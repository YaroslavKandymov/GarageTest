using UnityEngine;

namespace Garage.StaticData
{
    [CreateAssetMenu(fileName = "new KeyCodesData", menuName = "StaticData/KeyCodesData", order = 2)]
    public class KeyCodesData : ScriptableObject
    {
        [SerializeField] private KeyCode _takeItemCode;

        public KeyCode TakeItemCode => _takeItemCode;
    }
}