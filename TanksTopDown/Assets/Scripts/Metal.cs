using UnityEngine;

public class Metal : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            FindObjectOfType<Sounds>().PlayMetalSound();
        }
    }
}
