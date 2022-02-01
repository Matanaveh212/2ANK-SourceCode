using UnityEngine;
using System.Collections;
using TMPro;
public class Tank_BLUE : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float bulletForce;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject FirePoint;
    [SerializeField] float fireRate = 4;

    [SerializeField] TMP_Text scoreText;

    [SerializeField] GameObject explosion;

    public int health = 3;
    public int wins = 0;

    public string myBlueName;

    float nextTimeToFire = 0;

    private void Start()
    {
        transform.position = new Vector2(-4.514f, -1.529f);
    }

    void Update()
    {
        Movement();
        Shooting();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Bullet"))
        {

            FindObjectOfType<Sounds>().PlayHitSound();

            health -= 1;

            scoreText.text = health.ToString();

            StartCoroutine("ChangeColor");

            if(health <= 0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        
        FindObjectOfType<Sounds>().PlayDeathSound();

        Tank_RED redTank = FindObjectOfType<Tank_RED>();

        redTank.wins += 1;
        int redWins = redTank.wins;

        FindObjectOfType<GameMenuManager>().EndGameBlueLost();

        Destroy(redTank.gameObject);
        Destroy(gameObject);
    }

    IEnumerator ChangeColor()
    {
        Instantiate(explosion, transform.position, transform.rotation);

        GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Shooting()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextTimeToFire)
        {
            FindObjectOfType<Sounds>().PlayShotSound();

            nextTimeToFire = Time.time + 1 / fireRate;

            GameObject blueBullet = Instantiate(bullet, FirePoint.transform.position, FirePoint.transform.rotation);
            blueBullet.transform.parent = GameObject.Find("Bullets").transform;
            blueBullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.transform.up * -bulletForce, ForceMode2D.Impulse);
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }
}
