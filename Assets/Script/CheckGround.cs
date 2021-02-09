using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private bool _onGround = false;

    public bool OnGround => _onGround;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            _onGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            _onGround = true;
        }
    }
}
