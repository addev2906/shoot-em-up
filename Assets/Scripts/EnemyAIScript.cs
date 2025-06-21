using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class EnemyAIScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject bulletPrefab;
    public Transform[] shootPoint;
    public float bulletForce = 20f;
    public BulletScript bulletScript;
    private AudioScript audio;
    private Transform playerTransform;
    private float timer = 0f;
    private PlayerMovementScript playerMovementScript;
    [SerializeField] float enemySpeed=10f;
    [SerializeField] float bulletInterval;
    [SerializeField] float enemyHeath = 5f;


    private void Start()
    {
        playerMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScript>();

    }
    private void Update()
    {
        if (playerMovementScript.isAlive)
        {
            Vector2 enemyDir = (playerTransform.position - transform.position).normalized;
            rb.velocity = enemyDir * enemySpeed;

            float rotZ = Mathf.Atan2(enemyDir.y, enemyDir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotZ - 90);

            timer += Time.deltaTime;
            if (timer > bulletInterval)
            {
                Shoot();
                timer = 0f;
            }
        }
    }
    public void Shoot()
    {
        for (int i = 0; i<(shootPoint.Length); i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint[i].position, shootPoint[i].rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.AddForce(shootPoint[i].up * bulletForce, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet") { enemyHeath -= 1;audio.enemyHit(); }
        if (enemyHeath <= 0) { playerMovementScript.IncScore(); ; Destroy(gameObject);}
    }
}
