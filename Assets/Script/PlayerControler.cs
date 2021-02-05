using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private CheckGround _checkGround;
    [SerializeField] private UIScore _uIScore;
    [SerializeField] private UILives _uILives;
    [SerializeField] private int lives = 3;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;

    private void Awake()
    {
        _playerInput = new PlayerInput();

        _playerInput.Player.Jump.performed += ctx => OnJump();

        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        lives++;
        LivesCollision();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void Update()
    {
        _direction = _playerInput.Player.Move.ReadValue<Vector2>();

        RenderFlip(_direction);
        Animator(_direction);
        Move(_direction);
        OnJumpAnimation();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Move(Vector2 direction)
    {
        if (_checkGround.Jump)
        {
            _rigidbody.AddForce(new Vector3(direction.x, 0, 0) * _speed * Time.deltaTime, ForceMode2D.Force);
        }
    }

    private void OnJump()
    {
        if (_checkGround.Jump)
        {
            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Impulse);
        }
    }

    private void OnJumpAnimation()
    {
        if (_checkGround.Jump)
        {
            _animator.SetBool("Jump", false);
        }
        else
        {
            _animator.SetBool("Jump", true);
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

    private void Animator(Vector2 direction)
    {
        if (_checkGround.Jump)
        {
            if (direction.x != 0)
            {
                _animator.SetBool("Run", true);
                _animator.SetBool("Idle", false);
            }
            else
            {
                _animator.SetBool("Run", false);
                _animator.SetBool("Idle", true);
            }
        }
    }

    public void LivesCollision()
    {
        if (lives > 0)
        {
            _uILives.Lives(--lives);
        }
    }

    public void GemCollision()
    {
        _uIScore.Score();
    }
}
