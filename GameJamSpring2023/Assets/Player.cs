using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    float PrevInput;
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
        if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKey(KeyCode.Space) && grounded && Mathf.Abs(rb.velocity.y) <= .01f)
        {
            FindObjectOfType<audioManager>()?.Play("hop");
            rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
            Debug.Log("Hop");
            
        }

        //rb.AddForce(Vector2.right * input * 250);
        rb.velocity = new Vector2(input * 15, rb.velocity.y);;
        //transform.Translate(Vector3.right * Time.deltaTime * input * 15);

        //update animator

        //if ferret is midair, allow him to jump
        animator.SetBool("grounded", grounded);

        //if ferret is moving right, alert the animator
        if (input > 0)
        {
            if(!animator.GetBool("isMovingRight") && grounded)
            {
                animator.ResetTrigger("spin");
                animator.SetTrigger("spin");
            }
            animator.SetBool("isMovingRight", true);
            sprtrend.flipX = false;
        }
        else if (input < 0)
        {
            if(animator.GetBool("isMovingRight") && grounded)
            {
                animator.ResetTrigger("spin");
                animator.SetTrigger("spin");
            }
            animator.SetBool("isMovingRight", false);
            sprtrend.flipX = true;
        }
        
        //find out when to idle
        if(input == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
            FindObjectOfType<audioManager>()?.Play("footstep");
        }

        PrevInput = input;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
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
