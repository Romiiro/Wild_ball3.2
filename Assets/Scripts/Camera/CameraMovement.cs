using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    private Vector3 _offset;

    void Start() {
        _offset = transform.position - _playerTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate() {
        transform.position = _playerTransform.position + _offset;
    }
}
