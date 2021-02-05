using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private bool _jump = false;

    public bool Jump => _jump;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            _jump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Ground ground))
        {
            _jump = true;
        }
    }
}
