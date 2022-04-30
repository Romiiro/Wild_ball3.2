#region

using UnityEngine;

#endregion

[RequireComponent(typeof(Rigidbody))]
public class PlayerJumping : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _jumpPower = 1;
    [SerializeField] private int _groundLayerNum;
    [SerializeField] private LayerMask _groundLayerMask;
    
    private bool _jumping = false;
    private bool _onGround;
    private DirectionCalculator _dc;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _dc = GetComponent<DirectionCalculator>();
    }

    void FixedUpdate()
    {
        if (_jumping) {
            Jumping();
        }
    }
    private void OnCollisionExit(Collision other) {
        _onGround = false;
    }

    /// <summary>
    /// Метод для прыжка. Если игрок не в воздухе устанавливает флаг прыжка в положение true.
    /// Прыжок будет выполнен при следующем вызове FixedUpdate
    /// </summary>
    public void PlayerJump() {
        if (_onGround) {
            _jumping = true;
            _onGround = false;
        }
    }

    private void OnCollisionStay(Collision collision) {
        foreach (var point in collision.contacts)
        {
            Vector3 normal = point.normal;
            CheckGround(normal);
        }
    }

    private void CheckGround(Vector3 direction) {
        if (direction.y > 0.90) {
            _onGround = true;
        };
    }

    /// <summary>
    /// Прикладывает силу для прыжка.
    /// </summary
    private void Jumping() {
        Vector3 jumpDirection = _dc.CalculateJumpDirection();
        _rb.AddForce(jumpDirection * _jumpPower, ForceMode.Impulse);
        _jumping = false;
    }
}
