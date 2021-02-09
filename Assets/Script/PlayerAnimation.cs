using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private CheckGround _checkGround;

    private Player _player;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Animator(_player.Direction);
        OnJumpAnimation();
    }

    private void OnJumpAnimation()
    {
        if (_checkGround.OnGround)
        {
            _animator.SetBool("Jump", false);
        }
        else
        {
            _animator.SetBool("Jump", true);
        }
    }

    private void Animator(Vector2 direction)
    {
        if (_checkGround.OnGround)
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
}
