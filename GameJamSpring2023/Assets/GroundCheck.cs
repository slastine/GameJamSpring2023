using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool Grounded { get; private set; }

    private void Start() =>
        Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), transform.parent.GetComponent<CapsuleCollider2D>());

    private void OnTriggerEnter2D(Collider2D collision) =>
        Grounded = true;
    
    private void OnTriggerExit2D(Collider2D collision) =>
        Grounded = false;

    private void OnTriggerStay2D(Collider2D collision) =>
        Grounded = true;

    private void Update() => 
        transform.position = transform.parent.position;
}
