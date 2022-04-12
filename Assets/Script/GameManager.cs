using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;

    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;
    public GameObject GameUI;

    // Update is called once per frame
    void Update(){
        //Escape key press to move toward pause UI
        if (Input.GetKeyDown(KeyCode.Escape)){
           // Debug.Log("Key pressed");
            if(GameisPaused){
               // Debug.Log("IF");
                Resume();
            }
            else{
               // Debug.Log("Else");
                Pasue();
            }
        }
    }

    //Resume function start
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameisPaused = false;
        Cursor.visible = false;
        GameUI.SetActive(true);
    }
    //Resume function ends
    //Pause function start
    void Pasue(){
        pauseMenuUI.SetActive(true);
        GameUI.SetActive(false);
        Time.timeScale = 0f;
        GameisPaused = true;
        Cursor.visible = true;
    }
    //Pause function Ends
    //Load function start
    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    //Load function Ends
    //Quit function start
    public void QuitGame(){
        #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
    }
    //Load function Ends
    //PlayGamed function start
    public void PlayGame(){
         //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 1);
         SceneManager.LoadScene(1);
    }
    //Update function start
    public void UpdateScore(int scoreToAdd){
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    //Update function Ends
}
