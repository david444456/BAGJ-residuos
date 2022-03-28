using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/GameData", order = 0)]
public class GameData : ScriptableObject
{
    [SerializeField] private bool _usedMobile = true;

    public bool UsedMobile => _usedMobile;
}
