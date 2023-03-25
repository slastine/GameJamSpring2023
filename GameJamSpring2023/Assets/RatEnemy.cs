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

    IEnumerator GoToPos(Vector2 target)
    {
        while (Vector2.Distance((Vector2)rat.transform.position, target) > .1f)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = (target - (Vector2)rat.transform.position).x < 0;
            rat.transform.position = Vector2.MoveTowards(rat.transform.position, target, .01f);
            yield return null;
        }
    }

    IEnumerator GoToPos1()
    {
        yield return GoToPos(pos1);
        StartCoroutine("GoToPos2");
    }

    IEnumerator GoToPos2()
    {
        yield return GoToPos(pos2);
        StartCoroutine("GoToPos1");
    }
}
