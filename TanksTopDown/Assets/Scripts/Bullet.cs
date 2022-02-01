using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int bulletHealth = 3;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bulletHealth -= 1;

        if(bulletHealth <= 0)
        {
            Destroy(gameObject);
        }

        if(collision.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if(collision.collider.CompareTag("Wood"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
