using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    public class SetSkinMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _contentGO;
        [SerializeField] private GameObject _startMenu;
        [SerializeField] private CustomizeData _data;

        [Header("UI")]
        [SerializeField] private InfoSkin[] _infoSkins;

        private Button[] _buttonsCustomize;

        private void Start()
        {
            _buttonsCustomize = _contentGO.GetComponentsInChildren<Button>();

            for (int i = 0; i < _infoSkins.Length && i <_buttonsCustomize.Length; i++)
            {
                Image[] images = _buttonsCustomize[i].GetComponentsInChildren<Image>();
                for (int j = 0; j < images.Length; j++) {
                    if(images[j].gameObject != _buttonsCustomize[i].gameObject)
                        images[j].sprite = _infoSkins[i].SpriteImagesSkin;
                }

                Text text = _buttonsCustomize[i].GetComponentInChildren<Text>();
                text.text = _infoSkins[i].NameSkin;

                int index = i;
                _buttonsCustomize[i].onClick.AddListener(() => 
                {
                    _startMenu.SetActive(true);
                    SetCustomizeSkingToId(index);
                    gameObject.SetActive(false);
                });
            }
        }

        private void SetCustomizeSkingToId(int id)
        {
            _data.IdSking = id;
        }
    }
}