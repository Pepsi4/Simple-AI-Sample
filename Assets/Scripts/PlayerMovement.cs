using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _speed = 1f;

    public Vector2 MoveVector { get; set; }

    public void Move()
    {
        this.transform.Translate(MoveVector * Time.deltaTime * _speed);
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        _playerInput.Player.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Player.Disable();
    }

    private void FixedUpdate()
    {
        MoveVector = _playerInput.Player.Move.ReadValue<Vector2>();
    }

    private void Update()
    {
        Move();
    }
}