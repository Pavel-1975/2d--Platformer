using UnityEngine;

public class Gem : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerControler playerControler))
        {
            playerControler.GemCollision();    
            Destroy(gameObject);
        }
    }
}
