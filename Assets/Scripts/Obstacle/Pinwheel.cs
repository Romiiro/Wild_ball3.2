#region

using UnityEngine;

#endregion

public class Pinwheel : MonoBehaviour {
    private Rigidbody _rb;
    [SerializeField] private Vector3 _rotationSpeed;


    void Start() {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        Quaternion curRotation = gameObject.transform.rotation;
        Quaternion deltaRotation = Quaternion.Euler(_rotationSpeed * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * deltaRotation);
    }
}
