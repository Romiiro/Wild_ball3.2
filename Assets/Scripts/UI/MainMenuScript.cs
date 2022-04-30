#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class MainMenuScript : MonoBehaviour {
    [SerializeField] private GameSettings _gameSettings;
    private AudioSource _audio;

    public void PlayButtonSound() {
        _audio.Play();
    }

    public void LoadLevel(int index) {
        _gameSettings.SetTimeSpeed(1);
        SceneManager.LoadScene(index);
    }

    private void Start() {
        _audio = GetComponent<AudioSource>();
    }
}