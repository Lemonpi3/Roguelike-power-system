using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Player player;
    PlayerInputs _playerInputs;
    Vector2 _moveInput;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void OnEnable()
    {
        _playerInputs = new PlayerInputs();
        _playerInputs.PC.Enable();
    }

    void OnDisable()
    {
        _playerInputs = new PlayerInputs();
        _playerInputs.PC.Disable();
    }

    void FixedUpdate()
    {
        _moveInput = _playerInputs.PC.Movement.ReadValue<Vector2>();
        transform.Translate(_moveInput * player.moveSpeed * Time.deltaTime);
    }
}
