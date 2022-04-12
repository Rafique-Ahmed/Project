using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyshooting : MonoBehaviour
{
    //This script will shoot player when player will be detect 
    public float speed;
    public float stoppingDistance;
    public float retreaDistance;
    
    private float timeBtwShots;
    public float startTimeBtwShots;




    public Transform player;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player").transform;
         timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
             transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if(Vector3.Distance(transform.position, player.position) > stoppingDistance && Vector3.Distance(transform.position, player.position) > retreaDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, player.position) > retreaDistance)
        {
        transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBtwShots <= 10){
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }else{
            timeBtwShots -= Time.deltaTime;
        }
        
    }
}
