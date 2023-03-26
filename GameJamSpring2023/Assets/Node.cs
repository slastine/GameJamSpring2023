using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public GameObject[] activated;
    public List<IOnNodeActivate> toActivate = new List<IOnNodeActivate>();
    public Gizmo gizmo;

    public void Start()
    {
        for (int i = 0; i < activated.Length; i++)
        {
            toActivate.Add((IOnNodeActivate)activated[i].GetComponent(typeof(IOnNodeActivate)));
        }
    }

    public void Activate()
    {
        for (int i = 0; i < toActivate.Count; i++)
        {
            toActivate[i].OnConnect();
        }
    }

    public void Deactivate()
    {
        for (int i = 0; i < toActivate.Count; i++)
            toActivate[i].OnDisconnect();
    }


}
