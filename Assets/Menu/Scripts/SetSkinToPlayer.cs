using UnityEngine;

namespace Character
{
    public class SetSkinToPlayer : MonoBehaviour
    {
        [SerializeField] private GameObject[] _gameObjectsSkins;
        [SerializeField] private CustomizeData _dataPlayer;

        private void Start()
        {
            foreach (GameObject skin in _gameObjectsSkins)
            {
                skin.SetActive(false);
            }

            if (_dataPlayer.IdSking < _gameObjectsSkins.Length)
            {
                _gameObjectsSkins[_dataPlayer.IdSking].SetActive(true);
            }
        }
    }
}
