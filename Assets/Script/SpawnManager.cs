using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject GameUI;
    //This script will spawn enemy
    public GameObject GameWinUI;

    public GameObject enemyPrefab;
    private float SpawnRange = 22;
    public int enemyCount;

    public int waveNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private Vector3 GenerateSpawnPosition() { 
        float spawnPosX = Random.Range(-SpawnRange, SpawnRange);
        float spawnPosZ = Random.Range(-SpawnRange, SpawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    void  SpawnEnemyWave(int enemiesToSpawn){
        for(int i = 0; i < enemiesToSpawn; i++){
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<AIController>().Length;
        if(enemyCount == 0){
            waveNumber++;
            if(waveNumber>5){
                GameWinUI.SetActive(true);
                Time.timeScale = 0f;
                Cursor. visible = true;
                GameUI.SetActive(false);
            }

            else {
                SpawnEnemyWave(waveNumber);}
        }
    }
}
