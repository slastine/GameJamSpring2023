using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGen : MonoBehaviour
{
    public float Offset = 3.3f;
    public GameObject Chain;
    public uint Count = 5;
    public GameObject Player;

    void Start()
    {
        HingeJoint2D joint = null;
        SpringJoint2D d = null;

        for (uint i = 0; i < Count; i++) 
        {
            var c = Instantiate(Chain, transform);
            c.transform.Translate(new Vector2(2f + i * Offset, 0));
            var hinges = c.GetComponents<HingeJoint2D>();
            var dists = c.GetComponents<SpringJoint2D>();

            if (i != 0)
            {
                dists[0].connectedBody = hinges[0].connectedBody = joint.GetComponent<Rigidbody2D>();
                d.connectedBody = joint.connectedBody = c.GetComponent<Rigidbody2D>();
            }
            else
            {
                dists[0].connectedBody = hinges[0].connectedBody = transform.GetComponent<Rigidbody2D>();
            }
            if (i == Count - 1)
            {
                dists[1].connectedBody = hinges[1].connectedBody = Player.GetComponent<Rigidbody2D>();
            }
            joint = hinges[1];
            d = dists[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
