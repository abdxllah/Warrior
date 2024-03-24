using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTime : MonoBehaviour
{
   //changing to the game after intial cutscene 

   public float changeTime;
   

   private void Update(){
    changeTime -= Time.deltaTime;
    if(changeTime <= 0){
        SceneManager.LoadScene("Main");
        
    }
   }
}
