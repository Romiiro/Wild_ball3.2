#region

using UnityEngine;

#endregion

[CreateAssetMenu(menuName = "ScriptableObject/GameSettings")]
public class GameSettings : ScriptableObject {
    public void SetTimeSpeed(float speed) {
        Time.timeScale = speed;
    }
}