using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private ScoreSystem _scoreSystem;

    private void Update() {
        _scoreText.text = _scoreSystem.GetScore().ToString();
    }
}
