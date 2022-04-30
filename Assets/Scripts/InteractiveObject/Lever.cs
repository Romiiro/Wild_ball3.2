#region

using UnityEngine;
using UnityEngine.UI;

#endregion

public class Lever : MonoBehaviour
{
    [SerializeField] private string _tooltipText;
    [SerializeField] private Animator[] _connectedObjectAnimators;
    [SerializeField] private Text _tooltip;

    private PlayerInteraction _pInteraction;
    private bool _notActivated = true;
    private Animator _anim;

    void Start() {
        _anim = GetComponent<Animator>();
    }

    /// <summary>
    /// јктивирует анимацию, обновл€ет всплывающее сообщение
    /// и отписываетс€ от событи€ действий игрока.
    /// </summary>
    public void Activate() {
        _pInteraction.UnRegisterListener(Activate);
        _anim.SetTrigger("Activated");
        _tooltipText = "";
        _tooltip.text = _tooltipText;
    }
    
    public void ActivateConnectedObject() {
        foreach(var anim in _connectedObjectAnimators) {
            anim.SetTrigger("Opened");
        }
    }

    /// <summary>
    /// ѕри контакте с игроком, подписываетс€ на событие действи€ игрока
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && _notActivated) {
            _pInteraction = other.GetComponent<PlayerInteraction>();
            _pInteraction.RegisterListener(Activate);
            _tooltip.text = _tooltipText;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            _pInteraction.UnRegisterListener(Activate);
            _pInteraction = null;
            _tooltip.text = "";
        }
    }
}
