using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    //Mouse click detection on Enemy

    //bullet Sound variables 
    public AudioClip shootsound;
    private AudioSource playerAudio; 

    public ParticleSystem explosionParticle;
    public float demage = 10f;
    public float range = 100f;  
    public Camera fpsCam;
    

    void Start()
    {
        //Audio component decleration
        playerAudio = GetComponent<AudioSource>();
    }
    void Update(){
        if (Input.GetButtonDown("Fire1")){
            Shoot();
        }          
    }
//Player shoot function  start
    private void Shoot(){
        RaycastHit hit;
        
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
          //  Debug.Log(hit.transform.name);
            explosionParticle.Play();
            playerAudio.PlayOneShot(shootsound, 1.0f);
            Target  target = hit.transform.GetComponent<Target>();
            if(target != null){
                target.TakeDamage(demage);
            }
        }
    }
    //Player shoot function  ends
}
