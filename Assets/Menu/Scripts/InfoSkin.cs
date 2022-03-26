using UnityEngine;

namespace Character
{
    [System.Serializable]
    public class InfoSkin
    {
        [SerializeField] private Sprite _spriteImagesSkin;
        [SerializeField] private string _nameSkin;

        public Sprite SpriteImagesSkin => _spriteImagesSkin;

        public string NameSkin => _nameSkin;
    }
}