using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
public class LevelDataSo : ScriptableObject
{
    public string levelName = "Level";
    public int keysRequired = 3;
    public string nextScene;
}
