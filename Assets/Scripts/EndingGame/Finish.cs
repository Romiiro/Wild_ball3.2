#region 

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class Finish : MonoBehaviour
{
    [SerializeField] private UnityEvent _winEvent;
    [SerializeField] private Text _tooltip;
    [SerializeField] private ScoreSystem _scoreSystem;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (_scoreSystem.IsAllCoinsCollected()) {
                _winEvent.Invoke();
                StartCoroutine(WinTimer());
            } else {
                PrintHintMessage();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            _tooltip.text = "";
        }
    }

    private void PrintHintMessage() {
        var msg = "Для перехода на следующий уровень соберите все монетки.\n" +
                  "Осталось собрать " + _scoreSystem.CoinsLeft() + " монет.";
        _tooltip.text = msg;
    }

    /// <summary>
    /// Отображает таймер победы, и загружает следующий уровень.
    /// Если это был последний уровень переходит в меню
    /// </summary>
    /// <returns></returns>
    private IEnumerator WinTimer() {
        var sceneCount = SceneManager.sceneCountInBuildSettings;
        var msg = "Поздравляю! \n Следующий уровень начнется через: ";
        if (SceneManager.GetActiveScene().buildIndex == sceneCount - 1) {
            msg = "Поздравляю, игра пройдена! \nВозвращение в меню через: ";
        }

        for (var i = 3; i >= 0; i--) {
            _tooltip.text = msg + i;
            yield return new WaitForSeconds(1);
        }

        if (SceneManager.GetActiveScene().buildIndex == sceneCount - 1) {
            SceneManager.LoadScene(0);
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
