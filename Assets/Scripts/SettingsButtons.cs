using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsButtons : MonoBehaviour
{

    //script to deal with activating online access and letting users pick their settings for how the game should play out

    public Button setting1;
    public Button setting2;

    public TMP_Text textmeshPro;
    public TMP_Text textmeshPro2;
    public GameObject textmeshConnection;
    
        
    
    public bool setting1Active;
    public bool setting2Active;
    // Start is called before the first frame update
    void Start()
    {
        
        textmeshConnection.SetActive(false);
        setting1.GetComponent<Image>().color = Color.black;
        setting2.GetComponent<Image>().color = Color.black;
        textmeshPro.color = new Color32(255, 255, 255, 70);
        textmeshPro2.color = new Color32(255, 255, 255, 70);
        setting1Active = false;
        SettingsVariables.crewStatus = false;
        SettingsVariables.onlineClassifier = false;
        setting2Active = false;
        setting1.onClick.AddListener(ActivateCrew);
        setting2.onClick.AddListener(ActivateOnlineClassifier);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateCrew(){
      
        if (setting1Active == false){
            if(Application.internetReachability == NetworkReachability.NotReachable)
                {
                Debug.Log("failed connection");
                SettingsVariables.crewStatus = false;
                textmeshConnection.SetActive(true);
                }else{
                    textmeshConnection.SetActive(false);
                    Debug.Log("activate crew true");
                    setting1.GetComponent<Image>().color = Color.white;
                    textmeshPro.color = new Color32(255, 255, 255, 255);
                    setting1Active = true;
                    SettingsVariables.crewStatus = true; }
        }
        else{
            Debug.Log("activate crew false");
           
            setting1.GetComponent<Image>().color = Color.black;
           textmeshPro.color = new Color32(255, 255, 255, 70);
           setting1Active = false;
           SettingsVariables.crewStatus = false;
            
        }
    }


    void ActivateOnlineClassifier(){
         if (setting2Active == false){
            if(Application.internetReachability == NetworkReachability.NotReachable)
                {
                 Debug.Log("failed connection");
                 SettingsVariables.onlineClassifier = false;
                 textmeshConnection.SetActive(true);
                }else{
                    textmeshConnection.SetActive(false);
                     Debug.Log("activate classifier true");
                     setting2.GetComponent<Image>().color = Color.white;
                     textmeshPro2.color = new Color32(255, 255, 255, 255);
                    setting2Active = true;
                    SettingsVariables.onlineClassifier = true;}
        }
        else{ 
            Debug.Log("activate classifier false");
            setting2.GetComponent<Image>().color = Color.black;
           textmeshPro2.color = new Color32(255, 255, 255, 70);
            setting2Active = false;
            SettingsVariables.onlineClassifier = false;
        }
    }



}

    
