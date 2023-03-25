using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingDoor : MonoBehaviour, IOnNodeActivate
{
    public Vector2 startPos;
    public Vector2 endPos;
    public GameObject door;
    public float waitTime;
    public float moveSpeed = .001f;

    IEnumerator Raise()
    {

        while (Vector2.Distance((Vector2)door.transform.position, endPos) > .1f)
        {
            door.transform.position = Vector2.MoveTowards(door.transform.position, endPos, .1f);
            Debug.Log("Moving up");
            yield return null;
        }
            StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(waitTime);

        StartCoroutine("Close");
    }

    IEnumerator Close()
    {
        while (Vector2.Distance((Vector2)door.transform.position, startPos) > .1f)
        {
            door.transform.position = Vector2.MoveTowards(door.transform.position, startPos, moveSpeed);

            yield return null;
        }

    }

    public void OnActivate()
    {
        StartCoroutine("Raise");
    }
}
