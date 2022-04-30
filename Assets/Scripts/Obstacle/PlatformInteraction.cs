#region

using UnityEngine;

#endregion

public class PlatformInteraction : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _velocity;
    private Vector3 _velocityDelta;
    private PlayerMovement _contactObject;
    private float _playerDrag;

    /// <summary>
    /// При старте обнуляем переменные.
    /// </summary>
    private void Start() {
        _rb = gameObject.GetComponent<Rigidbody>();
        _velocity = Vector3.zero;
        _velocityDelta = Vector3.zero;
        _contactObject = null;
    }

    private void FixedUpdate() {
        if (_contactObject != null) {
            VelocityTransmisson();
        }
    }

    /// <summary>
    /// Рассчитываем компенсацию сопротивления воздуха.
    /// Передаем связанному объекту разницу скорости между двумя кадрами с учетом компенсации.
    /// </summary>
    private void VelocityTransmisson() {
        Vector3 dragCompensation = _velocity * Time.fixedDeltaTime * _playerDrag;
        _velocityDelta = _rb.velocity - _velocity + dragCompensation;
        _velocity = _rb.velocity;
        _contactObject.AddVelocity(_velocityDelta);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")) {
            PlayerEnter(other);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            PlayerExit(other);
        }
    }

    /// <summary>
    /// Метод вызываемый при входе игрока на платформу.
    /// Сохраняем ссылку на скрипт отвечающий за передвижение игрока.
    /// Запоминаем текущее сопротивление воздуха игрока.
    /// Обнуляем значение скорости в предыдущем кадре для создания эффекта прилипания.
    /// </summary>
    /// <param name="other"></param>
    private void PlayerEnter(Collider other) {
        _contactObject = other.gameObject.GetComponent<PlayerMovement>();
        Rigidbody playerRB = other.gameObject.GetComponent<Rigidbody>();
        _playerDrag = playerRB.drag;
        _velocity = Vector3.zero;
    }


    /// <summary>
    /// Метод описывающий действия при выходе игрока с платформы
    /// Обнуляем ссылку на объект
    /// <param name="other"></param>
    private void PlayerExit(Collider other) {
        _contactObject = null;
    }
}
