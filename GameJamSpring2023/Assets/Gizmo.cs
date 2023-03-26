using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public bool on;
    public SpriteRenderer ren;
    public Sprite active;
    public Sprite inactive;
    public SpriteRenderer lowerLayer;

    public void Start()
    {
        if (on)
        {
            ren.sprite = active;
        }
        else
        {
            ren.sprite = inactive;
        }
        lowerLayer.color = ChainTest.colors[PlayerPrefs.GetInt("Color")];
    }

    public void Activate()
    {
        on = !on;
        if(on)
        {
            ren.sprite = active;
        }
        else
        {
            ren.sprite = inactive;
        }
    }
}
