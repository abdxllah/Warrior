using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    //utility function as to pause the game and exit the game

    public GameObject paused;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        paused.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                DeactivateSettings();
            }
        


        }
    }

    public void SettingMenu(){
        paused.SetActive(true);
        
        isPaused = true;
    }

    public void DeactivateSettings(){
        paused.SetActive(false);
        
        isPaused = false;
    }
}
