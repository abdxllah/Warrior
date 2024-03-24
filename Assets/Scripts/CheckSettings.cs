using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSettings : MonoBehaviour
{

    public GameObject offline;
    public GameObject online;

    //script to check what the settings are and act accordingly 
    // Start is called before the first frame update
    void Start()
    {

        if (SettingsVariables.crewStatus){
            online.SetActive(true);
            offline.SetActive(false);
        }else{
            online.SetActive(false);
            offline.SetActive(true);
        }
    }

    
}
