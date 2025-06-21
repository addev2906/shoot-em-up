using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource bulletHitSource;
    public AudioSource enemyDamageSource;

    public void bulletHit()
    {
        bulletHitSource.Play();
    }

    public void enemyHit()
    {
        enemyDamageSource.Play();
    }
}
