using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTitle : MonoBehaviour
{
    
    public GameObject titleText;
    // script to show warrior when user is hovering over the main button
    public void Start()
    {
        titleText.SetActive(false);
    }

    public void OnMouseOver() {
        titleText.SetActive(true);
    }

    public void OnMouseExit() {
        titleText.SetActive(false);
    }


    
}
