using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovementScript : MonoBehaviour
{
    [HideInInspector]public Vector3 playerDir;
    [HideInInspector]public bool isAlive = true;
    public GameObject enemySpawner;
    public Slider slider;
    public DeathScreenTextScript deathScript;
    public WaveControllerScript wave;
    public float currentHealth;
    public TextMeshProUGUI textComponent;
    public int killCount = 0;
    private Vector2 moveInput;
    private Rigidbody2D playerRb;
    private Vector3 screenPosition;
    private Vector3 worldPosition;
    [SerializeField] float speed;
    [SerializeField] private float maxHealth=10f;


    private void Start()
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        currentHealth = maxHealth;
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        textComponent = GameObject.Find("KillText").GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.x = Input.GetAxisRaw("Horizontal");

        moveInput.Normalize();

        playerRb.velocity = (moveInput* speed);

        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 1;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        playerDir = (worldPosition - transform.position).normalized;
        float rotZ = Mathf.Atan2(playerDir.y, playerDir.x)*Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotZ-90);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Enemy" || collision.collider.tag == "BulletEnemy") 
        { 
            currentHealth  -= 1; 
            slider.value = currentHealth; 
        }
        if (currentHealth == 0) 
        { 
            Destroy(gameObject); 
            Destroy(enemySpawner); 
            isAlive = false; 
            deathScript.StartDialouge();
        }
    }

    public void IncScore()
    {
        killCount++;
        textComponent.text = "KILLS: " + killCount;
        wave.CheckNextWave();
    }
}
