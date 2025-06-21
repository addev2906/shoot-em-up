using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenTextScript : MonoBehaviour
{
    public Text textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject buttonObject;
    void Start() {textComponent.text = string.Empty;}

    public void StartDialouge() {StartCoroutine(TypeLine());}

    IEnumerator TypeLine()
    {
        foreach (char c in lines[0].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(0.5f);
        buttonObject.SetActive(true);
    }
}
