using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChainTest : MonoBehaviour
{
    public GameObject player;
    public GameObject tether;
    List<GameObject> gos = new List<GameObject>();
    public GameObject rope;
    public int count = 0;

    private void Start()
    {
        int num = getCount((Vector2)player.transform.position, (Vector2)tether.transform.position);
        List<Vector2> ps = getPoints((Vector2)player.transform.position, (Vector2)tether.transform.position, num);
        for(int i = 0; i < ps.Count; i++)
        {
            GameObject go = Instantiate(rope);
            go.transform.position = ps[i];
            gos.Add(go);
        }
        gos[gos.Count - 1].GetComponent<SpriteRenderer>().color = Color.magenta; 
        count = num;
        for(int i = 0; i < gos.Count; i++)
        {
            if(i == 0)
            {
                gos[i].GetComponents<HingeJoint2D>()[1].connectedBody = player.GetComponent<Rigidbody2D>();
                gos[i].GetComponents<HingeJoint2D>()[0].connectedBody = gos[i + 1].GetComponent<Rigidbody2D>();
            }
            else if(i < gos.Count - 1)
            {
                gos[i].GetComponents<HingeJoint2D>()[1].connectedBody = gos[i - 1].GetComponent<Rigidbody2D>();
                gos[i].GetComponents<HingeJoint2D>()[0].connectedBody = gos[i + 1].GetComponent<Rigidbody2D>();
            }
            else
            {
                gos[i].GetComponents<HingeJoint2D>()[1].connectedBody = gos[i - 1].GetComponent<Rigidbody2D>();
                gos[i].GetComponents<HingeJoint2D>()[0].enabled = false;

                AddDistanceJoint(gos[i]);
            }
        }
    }
    private void Update()
    {
        int num = getCount((Vector2)player.transform.position, (Vector2)tether.transform.position);
        if (num > count) Debug.Log("We need more points " + num);
        for(int i = 0; i < num - count; i++)
        {
            GameObject go = Instantiate(rope);
            gos[^1].GetComponents<HingeJoint2D>()[0].enabled = true;
            go.transform.position = gos[^1].transform.TransformPoint(gos[^1].GetComponents<HingeJoint2D>()[0].anchor);
            go.GetComponents<HingeJoint2D>()[1].connectedBody = gos[^1].GetComponent<Rigidbody2D>();
            gos.Add(go);
            
            gos[^2].GetComponents<HingeJoint2D>()[0].connectedBody = gos[^1].GetComponent<Rigidbody2D>();
            gos[^1].GetComponents<HingeJoint2D>()[0].enabled = false;
            
            if (i == 0)
                Destroy(gos[^2].GetComponent<DistanceJoint2D>());
            if (i == num - count - 1)
                AddDistanceJoint(go);
        }
        count = num;
    }

    public List<Vector2> getPoints(Vector2 pointA, Vector2 pointB, int num)
    {
        float diff_X = pointB.x - pointA.x;
        float diff_Y = pointB.y - pointA.y;
        int pointNum = num;

        var interval_X = diff_X / (pointNum + 1);
        var interval_Y = diff_Y / (pointNum + 1);

        List<Vector2> pointList = new List<Vector2>();
        for (int i = 1; i <= pointNum; i++)
        {
            pointList.Add(new Vector2(pointA.x + interval_X * i, pointA.y + interval_Y * i));
        }
        return pointList;
    }

    

static int gcd(int a, int b)
    {
        if (b == 0)
            return a;
        return gcd(b, a % b);
    }

    // Finds the no. of Integral points between
    // two given points.
    static int getCount(Vector2 p, Vector2 q)
    {
        // If line joining p and q is parallel to
        // x axis, then count is difference of y
        // values
        if (p.x == q.x)
            return (int)Mathf.Abs(p.y - q.y) - 1;

        // If line joining p and q is parallel to
        // y axis, then count is difference of x
        // values
        if (p.y == q.y)
            return (int)Mathf.Abs(p.x - q.x) - 1;

        return gcd((int)Mathf.Abs(p.x - q.x), (int)Mathf.Abs(p.y - q.y)) - 1;
    }

    void AddDistanceJoint(GameObject o)
    {
        var j = o.AddComponent<DistanceJoint2D>();
        j.distance = 0;
        j.autoConfigureDistance = false;
        j.autoConfigureConnectedAnchor = false;
        j.anchor = Vector2.zero;
        j.connectedAnchor = transform.position;
    }
}