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
    public float moveSpeedDown = .001f;
    public float moveSpeedup = .1f;
    public bool continous;
    public bool raising = false;

    public void Start()
    {
        if(continous)
        {
            StartCoroutine("Raise");
        }
    }

    IEnumerator Raise()
    {
        door.transform.position = startPos;
        while (Vector2.Distance((Vector2)door.transform.position, endPos) > .1f)
        {
            door.transform.position = Vector2.MoveTowards(door.transform.position, endPos, moveSpeedup);
            Debug.Log("Moving up");
            raising = true;
            yield return null;
        }
        raising = false;
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(waitTime);
    }

    IEnumerator Close()
    {
        yield return Wait();
        door.transform.position = endPos;
        while (Vector2.Distance((Vector2)door.transform.position, startPos) > .1f)
        {
            door.transform.position = Vector2.MoveTowards(door.transform.position, startPos, moveSpeedDown);

            yield return null;
        }
        if (continous)
        {
            StartCoroutine("Raise");
        }
    }

    public void OnConnect()
    {
        if(!raising)
        {
            StartCoroutine(Raise());
        }
        continous = true;
    }

    public void OnDisconnect()
    {
        continous = false;
    }
}
