using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
   //script to have the background continually move

    public float speed;

    [SerializeField]
    private Renderer bgRenderer;

    // Update is called once per frame
    void Update()
    {
        //Moving on the X axis
        bgRenderer.material.mainTextureOffset +=new Vector2(speed * Time.deltaTime, 0);
    }
}
