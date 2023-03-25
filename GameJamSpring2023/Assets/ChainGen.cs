using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainGen : MonoBehaviour
{
    public float Offset = 3.3f;
    public GameObject Chain;
    public uint Count = 5;
    public GameObject Player;
    public float MaxDist = 16f;

    void Start()
    {
        HingeGen();
    }

    void HingeGen()
    {
        HingeJoint2D joint = null;

        for (uint i = 0; i < Count; i++)
        {
            var c = Instantiate(Chain, transform);
            c.transform.Translate(new Vector2(2f + i * Offset, 0));
            var hinges = c.GetComponents<HingeJoint2D>();

            if (i != 0)
            {
                hinges[0].connectedBody = joint.GetComponent<Rigidbody2D>();
                joint.connectedBody = c.GetComponent<Rigidbody2D>();
            }
            else
            {
                hinges[0].connectedBody = transform.GetComponent<Rigidbody2D>();
            }
            if (i == Count - 1)
            {
                hinges[1].connectedBody = Player.GetComponent<Rigidbody2D>();
                var d = c.AddComponent<DistanceJoint2D>();
                d.maxDistanceOnly = true;
                d.autoConfigureConnectedAnchor = true;
                d.autoConfigureDistance = false;
                d.distance = MaxDist;
                d.connectedBody = GetComponent<Rigidbody2D>();
            }
            joint = hinges[1];
        }
    }
    void RopeGen()
    {
        RopeJoint j = null;

        for (uint i = 0; i < Count; i++)
        {
            var c = Instantiate(Chain, transform);
            c.transform.Translate(new Vector2(2f + i * Offset, 0));
            var ropes = c.GetComponents<RopeJoint>();

            if (i != 0)
            {
                //ropes[0].Remote = j.gameObject;
                j.Remote = ropes[0].gameObject;
            }
            else
            {
                ropes[0].Remote = gameObject;
            }
            if (i == Count - 1)
            {
                ropes[1].Remote = Player;
            }
            j = ropes[1];
        }
    }
}
