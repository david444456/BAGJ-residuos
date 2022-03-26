using UnityEngine;

namespace Character
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Customize", order = 0)]
    public class CustomizeData : ScriptableObject
    {
        [SerializeField] private int _idCurrent = 0;
        
        public int IdSking
        {
            get => _idCurrent;
            set => _idCurrent = value;
        }
    }
}
