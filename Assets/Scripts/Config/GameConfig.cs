using UnityEngine;
 
[CreateAssetMenu(fileName = "GameConfig", menuName = "Game configs/GameConfig")]
public class GameConfig : ScriptableObject
{
    [Header("General stats")]
    [Range(0,100)]
    public float velocity;
}