using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShootingScript : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    public AudioScript audio;
    [SerializeField] float bulletForce = 20f;

    private void Update() {if(Input.GetMouseButtonDown(0)) { Shoot();audio.bulletHit(); }}
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        //rb.velocity = Vector2.zero;
        rb.AddForce(shootPoint.up*bulletForce,ForceMode2D.Impulse);
    }

}
