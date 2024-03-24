using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoClick : MonoBehaviour
{
    //script to have no click needed for the input field
    
    public TMP_InputField field;
   
    void Start()
    {
        field.ActivateInputField();
    }

   

}
