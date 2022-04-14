using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    private GameManager gameManager;
    public TextMeshProUGUI EnemycountText;
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
       gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        EnemycountText.text = "Enemies " + enemyCount;
        if(enemyCount == 0){
            waveNumber++;
            if(waveNumber>5){
                GameWinUI.SetActive(true);
                Time.timeScale = 0f;
                GameUI.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                gameManager.gameOn = false;
            }

            else {
                SpawnEnemyWave(waveNumber);}
        }
    }
}
