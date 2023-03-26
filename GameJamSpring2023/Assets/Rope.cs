using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Rope : MonoBehaviour
{
    GameObject ConnectedNode;
    Rigidbody2D rb;
    public float ForceMagnitude = 15;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (ConnectedNode != null)
        {
            if ((ConnectedNode.transform.position - transform.position).magnitude > 2f)
            {
                ConnectedNode = null;
                return;
            }
            rb.AddForce((ConnectedNode.transform.position - transform.position).normalized * ForceMagnitude);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Node"))
        {
            ConnectedNode = collision.collider.gameObject;
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            Debug.Log("Game over");
            public void StartGame() => SceneManager.LoadScene(5);
        }
    }
}
