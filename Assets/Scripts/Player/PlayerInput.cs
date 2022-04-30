#region

using UnityEngine;

#endregion

public class PlayerInput : MonoBehaviour
{
    private Vector3 _movement;
    private PlayerMovement _pMovement;
    private PlayerInteraction _pInteraction;
    private PlayerJumping _pJumping;

    void Start() {
        _movement = new Vector3();
        _pMovement = GetComponent<PlayerMovement>();
        _pInteraction = GetComponent<PlayerInteraction>();
        _pJumping = GetComponent<PlayerJumping>();
    }

    void Update() {
        InputReading();
        MoveInputReading(Time.deltaTime);
    }

    private void FixedUpdate() {
        _pMovement.PlayerAddForce(_movement.normalized);
    }

    private void MoveInputReading(float delta) {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");
        _movement.x = movementX;
        _movement.z = movementZ;
    }

    private void InputReading() {
      if (Input.GetButtonDown("Jump")) {
          _pJumping.PlayerJump();
      }

      if (Input.GetKeyDown(KeyCode.E)) {
          _pInteraction.PlayerAction();
      }
    }
}
