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
    private Animator animator;
    private Transform trf;
    private SpriteRenderer sprtrend;
    // Start is called before the first frame update
    void Start()
    {
        rb = go.GetComponent<Rigidbody2D>();
        animator = go.GetComponent<Animator>();
        trf = go.GetComponent<Transform>();
        sprtrend = go.GetComponent<SpriteRenderer>();
        startPos = this.transform.position;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Camera.main.WorldToViewportPoint(this.transform.position));
        float input = Input.GetAxis("Horizontal");
        //
        if (Input.GetKey(KeyCode.Space) && grounded && Mathf.Abs(rb.velocity.y) <= .01f)
        {
            rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
            Debug.Log("Hop");
        }

        //rb.AddForce(Vector2.right * input * 250);
        rb.velocity = new Vector2(input * 15, rb.velocity.y);;
        //transform.Translate(Vector3.right * Time.deltaTime * input * 15);

        //update animator
        if(input == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

        //flip the sprite as needed, it rotates on the y axis.
        if (Input.GetAxis("Horizontal") > .25)
        {
            sprtrend.flipX = false;
        }
        if (Input.GetAxis("Horizontal") < -.25)
        {
            sprtrend.flipX = true;
        }
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
