using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public bool on;
    public ChainGen tether;
    public SpriteRenderer ren;
    public Sprite active;
    public Sprite inactive;
    public SpriteRenderer lowerLayer;

    public void Start()
    {
        lowerLayer.color = tether.colors[PlayerPrefs.GetInt("Color")];
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
