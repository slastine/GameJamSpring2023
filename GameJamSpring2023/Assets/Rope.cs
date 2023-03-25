using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    GameObject ConnectedNode;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (ConnectedNode is not null)
        {
            if ((ConnectedNode.transform.position - transform.position).magnitude > 2f)
            {
                ConnectedNode = null;
                return;
            }
            rb.AddForce((ConnectedNode.transform.position - transform.position).normalized * 5);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Node"))
        {
            ConnectedNode = collision.collider.gameObject;
        }
    }
}
