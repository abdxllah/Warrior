using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InputFocused : MonoBehaviour
{

    //script to stay focused on input field even after mouse input
    
    public TMP_InputField inputField;
    public GameObject gameField;
    // Start is called before the first frame update
    void Start()
    {

        if (gameField.activeSelf){
        EventSystem.current.SetSelectedGameObject(gameField);
        inputField.Select();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameField.activeSelf){
       
        if (EventSystem.current.currentSelectedGameObject != gameField)
        {
        EventSystem.current.SetSelectedGameObject(gameField);
        
        }
    }
    }
}

