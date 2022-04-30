#region

using UnityEngine;

#endregion

[CreateAssetMenu (menuName ="ScriptableObject/ScoreSystem")]
public class ScoreSystem : ScriptableObject {
    
    private int _coinsOnLevel;
    private int _totalScore;
    private int _levelScore;

    public void RegisterCoin() {
        _coinsOnLevel++;
    }

    public void CollectCoin() {
        _levelScore++;
        _coinsOnLevel--;
    }

    private void OnEnable() {
        ResetAllScore();
    }
    
    public bool IsAllCoinsCollected() {
        return _coinsOnLevel == 0;
    }

    public int CoinsLeft() {
        return _coinsOnLevel;
    }

    public void OnPlayerDeath() {
        ResetLevelScore();
    }

    public void OnPlayerWin() {
        _totalScore += _levelScore;
        ResetLevelScore();
    }

    public void OnRestartLevel() {
        ResetLevelScore();
    }

    public void OnExitGame() {
        ResetAllScore();
    }

    private void ResetAllScore() {
        _coinsOnLevel = 0;
        _totalScore = 0;
        _levelScore = 0;
    }

    private void ResetLevelScore() {
        _coinsOnLevel = 0;
        _levelScore = 0;
    }

    public int GetScore() {
        return _totalScore + _levelScore;
    }
}
