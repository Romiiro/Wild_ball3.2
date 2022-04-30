#region

using UnityEngine;
using UnityEngine.UI;

#endregion

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float _maxSpeed = 5;
    [SerializeField] private float _speed = 1;
    [SerializeField] private Text _tooltip;

    private bool _zeroedVelocity = false;
    private Rigidbody _rb;
    private DirectionCalculator _dc;
    private Vector3 _dir;
    

    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _dc = GetComponent<DirectionCalculator>();
    }

    private void FixedUpdate() {
        ControlSpeed();
        if (_zeroedVelocity) {
            _rb.velocity = Vector3.zero;
        }
    }

    public void AddVelocity(Vector3 velocity) {
        _rb.velocity += velocity;
    }
    
    /// <summary>
    /// ћетод дл€ приложени€ силы в заданном направлении
    /// </summary>
    /// <param name="direction">Ќаправление силы</param>
    public void PlayerAddForce(Vector3 direction) {
        _dir = _dc.CalculateDirectionAlongSurface(direction);
        if (!_zeroedVelocity) {
            _rb.AddForce(_dir * _speed);
        }
    }

    /// <summary>
    /// ћетод дл€ контрол€ скорости. ѕри превышении скорости устанавливает скорость равной максимальной.
    /// Ќе учитывает вертикальную скорость.
    /// </summary>
    private void ControlSpeed() {
        if (_rb.velocity.magnitude >= _maxSpeed) {
            var horizontalVelosity = new Vector2(_rb.velocity.x, _rb.velocity.z);
            var horizontalSpeed = horizontalVelosity.magnitude;
            if (horizontalSpeed >= _maxSpeed) {
                horizontalVelosity = horizontalVelosity.normalized * _maxSpeed;
                _rb.velocity = new Vector3(horizontalVelosity.x, _rb.velocity.y, horizontalVelosity.y);
            }
        }
    }

    /// <summary>
    /// ѕри победе обнул€ем скорость.
    /// </summary>
    public void OnWinGame() {
        _zeroedVelocity = true;
    }
}