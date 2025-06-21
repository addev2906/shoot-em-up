using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveControllerScript : MonoBehaviour
{
    public PlayerMovementScript player;
    public EnemySpawnerScript enemy;
    public GameObject textObject;
    private int waveNumber=1;
    private int killReq=5;
    private int x=0;
    private void Start()
    {
        StartCoroutine(waveText());
    }
    public void CheckNextWave()
    {
        if (enemy.timeInterval == 1&&player.killCount==killReq)
        {
            killReq+=7;waveNumber++;StartCoroutine(waveText());print(killReq+"otherIF"); 
        }
        if (player.killCount >= killReq*waveNumber&&enemy.timeInterval>1)
        {
            x++;
            print(killReq);
            waveNumber++;

            enemy.timeInterval -= 1;
            StartCoroutine(waveText());
            if (x == 3)
            {
                killReq = player.killCount + killReq;
            }
        }
    }
    private IEnumerator waveText()
    {
        Text text  = textObject.GetComponent<Text>();
        text.text = "WAVE " + waveNumber.ToString();
        textObject.SetActive(true);
        yield return new WaitForSeconds(3);
        textObject.SetActive(false);
    }
}
