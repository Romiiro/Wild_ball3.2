#region

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion

public class KillingObject : MonoBehaviour
{
    [SerializeField] private UnityEvent _killEvent;
    [SerializeField] private Text _tooltip;
    [SerializeField] private GameObject _deathPS;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            _killEvent.Invoke();
            Instantiate(_deathPS, other.transform.position, Quaternion.identity);
            StartCoroutine(ResurectionTimer());
        }
    }


    /// <summary>
    /// Отображает таймер воскрешения и перезагружает сцену.
    /// </summary>
    /// <returns></returns>
    private IEnumerator ResurectionTimer() {
        var msg = "Вы проиграли. \nВозрождение через: ";
        for (var i = 3; i >= 0; i--) {
            _tooltip.text = msg + i;
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
