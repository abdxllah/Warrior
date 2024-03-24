using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{

    public GameObject skip;
    // Start is called before the first frame update
    void Start()
    {
        skip.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)){

            skip.SetActive(true);
        }


        if (skip.activeSelf && Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("Main");
        }
    }

    
}
