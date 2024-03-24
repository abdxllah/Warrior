using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

//script to change the colour of a sprite, when a mouse is hovering over the sprite
   public Color startColor;
   public Color mouseOverColor;
   
   SpriteRenderer m_SpriteRenderer;


    void OnMouseOver() {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = mouseOverColor;
    }

    void OnMouseExit() {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
       
        m_SpriteRenderer.color = startColor;
    }
}
