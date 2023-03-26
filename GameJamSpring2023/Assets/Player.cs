using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject go;
    public Rigidbody2D rb;
    public bool grounded => transform.GetChild(0).GetComponent<GroundCheck>().Grounded;
    public float thrust;
    public Vector3 startPos;
    public Animator animator;
    private Transform trf;
    private SpriteRenderer sprtrend;
    float PrevInput;
    public Node connectedTo;

    void Start()
    {
        rb = go.GetComponent<Rigidbody2D>();
        animator = go.GetComponent<Animator>();
        trf = go.GetComponent<Transform>();
        sprtrend = go.GetComponent<SpriteRenderer>();
        startPos = transform.position;
        InitPrefs();
    }

    void InitPrefs()
    {
        if (!PlayerPrefs.HasKey("Color")) PlayerPrefs.SetInt("Color", 0);
        if (!PlayerPrefs.HasKey("Speed")) PlayerPrefs.SetFloat("Speed", 15f);
        if (!PlayerPrefs.HasKey("MasterVol")) PlayerPrefs.SetFloat("MasterVol", 1);
        if (!PlayerPrefs.HasKey("SfxVol"))  PlayerPrefs.SetFloat("SfxVol", 1);
        if (!PlayerPrefs.HasKey("MusicVol"))  PlayerPrefs.SetFloat("MusicVol", 1);
    }

    void FixedUpdate()
    {
        float speed = PlayerPrefs.GetFloat("Speed");
        float input = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKey(KeyCode.Space) && grounded && Mathf.Abs(rb.velocity.y) <= .01f)
        {
            FindObjectOfType<audioManager>()?.Play("hop");
            rb.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
            Debug.Log("Hop");
        }

        rb.velocity = new Vector2(input * speed, rb.velocity.y);;

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
}