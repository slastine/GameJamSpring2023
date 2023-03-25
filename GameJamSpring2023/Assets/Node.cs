using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject[] activated;
    public List<IOnNodeActivate> toActivate = new List<IOnNodeActivate>();

    public void Start()
    {
        for (int i = 0; i < activated.Length; i++)
        {
            toActivate.Add((IOnNodeActivate)activated[i].GetComponent(typeof(IOnNodeActivate)));
        }
    }
    public void Activate()
    {
        for(int i = 0; i < toActivate.Count; i++)
        {
            toActivate[i].OnActivate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Rope"))
        {
            Activate();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Rope"))
        {
            Activate();
        }
    }
}
