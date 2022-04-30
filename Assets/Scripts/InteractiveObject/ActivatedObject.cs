#region

using UnityEngine;

#endregion


public class ActivatedObject : MonoBehaviour {
    [SerializeField] private Animator _connectedObjectAnimator;
    private Animator _anim;

    void Start() {
        _anim = GetComponent<Animator>();
    }

    private void Activate() {
        _anim.SetTrigger("Activated");
    }

    public void ActivateConnectedObject() {
        _connectedObjectAnimator.SetTrigger("Activated");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            Activate();
        }
    }
}
