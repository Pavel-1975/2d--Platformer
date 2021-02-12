using UnityEngine;

public class Gem : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out MovePlayer player))
        {
            player.TakeGem();
            Destroy(gameObject);
        }
    }
}
