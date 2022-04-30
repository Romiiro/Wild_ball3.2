#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion

public class InGameMenu : MonoBehaviour {
    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene(0);
    }
}