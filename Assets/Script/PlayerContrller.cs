using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerContrller : MonoBehaviour
{
    public GameObject GameUI;
    // Life variables
    int life = 2;
    public TextMeshProUGUI LifeText;

    //Games over object
    public GameObject GameOverUI;
    //Health system
    public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;


    //Player movement variables
    private float horizontalInput;
    private float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Health decleration
        currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //Player Direction Inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }


    //Player Health and life function Start
    void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
        if(currentHealth == 0){
            if(life==0){
            Time.timeScale = 0f;
            GameOverUI.SetActive(true);
            Cursor.visible = true;
            GameUI.SetActive(false);
            }
            else{
                currentHealth = 100;
                healthBar.SetHealth(currentHealth);
                life--;
                LifeText.text = "Life " + life;
            }

        }
	}
    //Player Health and life function Ends
    //Player enmey attack projectile detection function Start
    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("Trigger");
        if(other.CompareTag("Fire")){
       // Debug.Log("if");
        TakeDamage(20);
        }
    }
        //Player enmey attack projectile detection function Ends

}
