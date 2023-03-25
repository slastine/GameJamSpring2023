using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject go;
    public Rigidbody2D rb;
    public bool grounded;
    public float thrust;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = go.GetComponent<Rigidbody2D>();
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Camera.main.WorldToViewportPoint(this.transform.position));
        float input = Input.GetAxis("Horizontal");
        //
        if (Input.GetKey(KeyCode.Space) && grounded && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        }
        transform.Translate(Vector3.right * Time.deltaTime * input * 15);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
