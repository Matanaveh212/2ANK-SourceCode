using UnityEngine;
using System.Collections;
using TMPro;

public class Tank_RED : MonoBehaviour
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

    public string myRedName;

    float nextTimeToFire = 0;

    private void Start()
    {
       transform.position = new Vector2(5.502f, 1.476f);
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

        Tank_BLUE blueTank = FindObjectOfType<Tank_BLUE>();

        blueTank.wins += 1;

        FindObjectOfType<GameMenuManager>().EndGameRedLost();

        Destroy(blueTank.gameObject);
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
        if(Input.GetKey(KeyCode.Return) && Time.time >= nextTimeToFire)
        {
            FindObjectOfType<Sounds>().PlayShotSound();

            nextTimeToFire = Time.time + 1 / fireRate;

            GameObject redBullet = Instantiate(bullet, FirePoint.transform.position, FirePoint.transform.rotation);
            redBullet.transform.parent = GameObject.Find("Bullets").transform;
            redBullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.transform.up * -bulletForce, ForceMode2D.Impulse);
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        }
    }
}
