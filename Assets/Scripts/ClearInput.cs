using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClearInput : MonoBehaviour
{
    // clearing the input field after enter
    public TMP_InputField clearIt;

    public void submittingClear(){
        clearIt.text = "";
    }
}
