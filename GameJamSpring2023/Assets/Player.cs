using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject go;
    public Rigidbody2D rb;
    public bool grounded;
    public float thrust;
    // Start is called before the first frame update
    void Start()
    {
        rb = go.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        }
        rb.AddForce(Vector2.right * 1 * input * Time.deltaTime * 200, ForceMode2D.Impulse);
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
