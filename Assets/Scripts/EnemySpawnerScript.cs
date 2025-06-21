using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    float x;
    float y;
    float timer;
    public GameObject enemySquare;
    public GameObject enemyHex;
    public PlayerMovementScript playerScript;
    public float timeInterval=4f;
    [SerializeField] float SafeZone = 4 * Mathf.Pow(2, 0.5f);

    private void Update()
    {

        timer += Time.deltaTime;

        if (timer > timeInterval) {
            x = Random.Range(-19, 19);
            y = Random.Range(-10, 10);

            if ((new Vector3(x, y, 0) - playerScript.transform.position).magnitude <= SafeZone * Mathf.Pow(2, 0.5f))
            {

                Vector3 playerToEnemyDir = (new Vector3(x, y, 0) - playerScript.playerDir).normalized;
                float angle = Mathf.Atan2(playerToEnemyDir.y, playerToEnemyDir.x);

                float newX = SafeZone * Mathf.Cos(angle) + playerScript.transform.position.x;
                float newY = SafeZone * Mathf.Sin(angle) + playerScript.transform.position.y;

                x = newX;
                y = newY;
            }

            int rand = Random.Range(0, 2);

            if (rand == 0){Instantiate(enemySquare, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0));}
            if (rand == 1){Instantiate(enemyHex, new Vector3(x, y, 0), Quaternion.Euler(0, 0, 0)); }
            timer = 0;
        }

    }
}
