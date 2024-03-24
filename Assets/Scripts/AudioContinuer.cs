using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContinuer : MonoBehaviour
{

    //script to continue ocean audio after cutscene
    private void Awake() {
        GameObject[] oceanObj = GameObject.FindGameObjectsWithTag("OceanSound");
        if (oceanObj.Length >1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
