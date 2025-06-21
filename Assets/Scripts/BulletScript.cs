using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private ParticleSystem particles;

    private void Start()
    {
        particles = GameObject.FindGameObjectWithTag("ParticleSystem").GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string _tag  = collision.collider.tag;
        if (_tag == "Enemy"||_tag=="Player"||_tag =="Wall")
        {
            ParticleSystem instantParticles = Instantiate(particles, transform.position, transform.rotation);
            instantParticles.Play();
            Destroy(instantParticles.gameObject,0.25f);
            Destroy(gameObject);
        }
    }
}
