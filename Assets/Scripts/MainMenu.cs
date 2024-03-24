using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //script to start game once the button has been clicked

    // Start is called before the first frame update
    public void PlayGame(){

        StartCoroutine(Waiting());
        Debug.Log("start game");
    }


    IEnumerator Waiting(){
       yield return new WaitForSeconds(1f); 
       SceneManager.LoadScene(1);
    }
}
