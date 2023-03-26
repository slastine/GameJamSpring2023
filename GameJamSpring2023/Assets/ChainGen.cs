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
    public static Color32[] colors = new Color32[]
    {
        new Color32(31, 63, 224, 255),
        new Color32(248, 11, 11, 255),
        new Color32(15, 132, 0, 255),
        new Color32(245, 255, 0, 255)
    };

    public List<RopeJoint> Rope = new List<RopeJoint>();

    void Start()
    {
        Player = GameObject.Find("Player");
        Chain.GetComponent<SpriteRenderer>().color = colors[PlayerPrefs.GetInt("Color")];
        HingeGen();
    }

    void HingeGen()
    {
        HingeJoint2D joint = null;

        for (uint i = 0; i < Count; i++)
        {
            var c = Instantiate(Chain, transform);
            c.GetComponent<SpriteRenderer>().color = colors[PlayerPrefs.GetInt("Color")];
            Debug.Log("*");
            c.transform.Translate(new Vector2(2f + i * Offset, 0));
            var hinges = c.GetComponents<HingeJoint2D>();
            Physics2D.IgnoreCollision(c.GetComponent<Collider2D>(), Player.GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(c.GetComponent<Collider2D>(), Player.transform.GetChild(0).GetComponent<Collider2D>());

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
            c.GetComponent<SpriteRenderer>().color = colors[PlayerPrefs.GetInt("Color")];
            c.transform.Translate(new Vector2(2f + i * Offset, 0));
            var ropes = c.GetComponents<RopeJoint>();

            foreach (var v in c.GetComponents<HingeJoint2D>()) v.enabled = false;
            Rope.AddRange(ropes);

            if (i != 0)
            {
                ropes[0].Remote = j.gameObject;
                //j.Remote = ropes[0].gameObject;
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

    private void FixedUpdate()
    {
        foreach (RopeJoint r in Rope) r.UpdateSegment();
    }
}
