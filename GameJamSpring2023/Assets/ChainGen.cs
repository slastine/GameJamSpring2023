using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGen : MonoBehaviour
{
    public float Offset = 3.3f;
    public GameObject Chain;
    public uint Count = 5;

    void Start()
    {
        HingeJoint2D joint = null;
        for (uint i = 0; i < Count; i++) 
        {
            var c = Instantiate(Chain, transform);
            c.transform.Translate(new Vector3(3.8f + i * Offset, 0, 0));
            var hinges = c.GetComponents<HingeJoint2D>();
            if (joint != null)
            {
                hinges[0].connectedBody = joint.GetComponent<Rigidbody2D>();
                joint.connectedBody = c.GetComponent<Rigidbody2D>();
            }
            else
                hinges[0].connectedBody = transform.GetComponent<Rigidbody2D>();
            joint = hinges[1];
            if (i == Count - 1) hinges[1].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}