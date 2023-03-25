using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : MonoBehaviour
{
    public Vector2 pos1;
    public Vector2 pos2;
    public GameObject rat;

    public void Start()
    {
        StartCoroutine("GoToPos1");
    }
    IEnumerator GoToPos1()
    {

        while (Vector2.Distance((Vector2)rat.transform.position, pos2) > .1f)
        {
            rat.transform.position = Vector2.MoveTowards(rat.transform.position, pos2, .01f);
            yield return null;
        }
        StartCoroutine("GoToPos2");
    }

    IEnumerator GoToPos2()
    {

        while (Vector2.Distance((Vector2)rat.transform.position, pos1) > .1f)
        {
            rat.transform.position = Vector2.MoveTowards(rat.transform.position, pos1, .01f);
            yield return null;
        }
        StartCoroutine("GoToPos1");
    }
}
