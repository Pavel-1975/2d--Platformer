using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerAnimation))]
public class Player : MonoBehaviour
{
    [SerializeField] private CheckGround _checkGround;
    [SerializeField] private float _heightOfJump = 7;
    [SerializeField] private float _speed;
    [SerializeField] private int lives = 3;

    private SpriteRenderer _spriteRenderer;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    private int _gemCout = 0;

    public Vector2 Direction => _direction;

    public event UnityAction<int> ScoreChangedLives;
    public event UnityAction<int> ScoreChangedGem;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += ctx => OnJump();

        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        NumberLives();
    }

    private void Update()
    {
        _direction = _playerInput.Player.Move.ReadValue<Vector2>();

        RenderFlip(_direction);
        Move(_direction);
    }

    private void Move(Vector2 direction)
    {
        if (_checkGround.OnGround)
        {
            _rigidbody.AddForce(new Vector3(direction.x, 0, 0) * _speed * Time.deltaTime, ForceMode2D.Force);
        }
    }

    private void OnJump()
    {
        if (_checkGround.OnGround)
        {
            _rigidbody.AddForce(Vector2.up * _heightOfJump, ForceMode2D.Impulse);
        }
    }

    private void RenderFlip(Vector2 direction)
    {
        if (direction.x > 0f)
        {
            _spriteRenderer.flipX = false;
        }
        else if (direction.x < 0f)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void NumberLives()
    {
        ScoreChangedLives?.Invoke(lives);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void EnemyCollision()
    {
        if (lives > 0)
        {
            ScoreChangedLives?.Invoke(--lives);
        }
    }

    public void GemCollision()
    {
        ScoreChangedGem?.Invoke(++_gemCout);
    }
}
