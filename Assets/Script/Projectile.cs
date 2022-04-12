using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Script of projectile to hit enemy
    public float speed;
    public Transform player;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player").transform;
         target = new Vector3(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
        }
    }


    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            DestroyProjectile();
            
        }
    }

    void DestroyProjectile(){
        Destroy(gameObject);
    }
}
