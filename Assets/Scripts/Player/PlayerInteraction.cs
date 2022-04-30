#region

using UnityEngine;
using UnityEngine.Events;

#endregion

public class PlayerInteraction : MonoBehaviour {
    [SerializeField] private UnityEvent _playerAction;

    public void RegisterListener(UnityAction action) {
        _playerAction.AddListener(action);
    }

    public void UnRegisterListener(UnityAction action) {
        _playerAction.RemoveListener(action);
    }

    public void PlayerAction() {
        _playerAction.Invoke();
    }
}
