using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    //utility function as to pause the game and exit the game

    public GameObject paused;
    public bool isPaused;
    public Button quit;
    public Button restart;
    // Start is called before the first frame update
    void Start()
    {
        paused.SetActive(false);

        quit.onClick.AddListener(QuitGame);
        restart.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }

       
    }

    public void PauseGame(){
        paused.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame(){
        paused.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void RestartGame(){
      Time.timeScale = 1f;
        isPaused = false;
        GameObject ocean = GameObject.FindGameObjectWithTag("OceanSound");
        Destroy(ocean);
        SceneManager.LoadScene(0);
        
 
    }

    public void QuitGame(){
        Debug.Log("quit");
        Application.Quit();
    }
}
