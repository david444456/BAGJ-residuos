using UnityEngine;

public class MobileControl : MonoBehaviour
{
    [SerializeField] private GameData _gameData;

    private void Awake()
    {
        gameObject.SetActive(_gameData.UsedMobile);
    }
}
