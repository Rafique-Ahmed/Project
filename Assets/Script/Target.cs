using UnityEngine;

public class Target : MonoBehaviour
{
    //Script to detect Enemy and kill enmey
    private GameManager gameManager;
    public float health = 50f;

    void Start() {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();    
    }
    //Takes Damage function start of Enemy Health
    public void TakeDamage(float amount){
       // Debug.Log("TakeDamage");
        health -= amount;
        if(health <= 0f){
            Die();
        }
    }
    //Takes Damage function end of Enemy Health
    //Die function start of Enemy Health
    void Die(){
       // Debug.Log("Die");
        gameManager.UpdateScore(5);
        Destroy(gameObject);
    }
    //Die function ends of Enemy 
}
