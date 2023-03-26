using System.Collections.Generic;
using UnityEngine;

public class ChainTest : MonoBehaviour
{
    public GameObject player;
    public GameObject tether;
    public List<GameObject> gos = new List<GameObject>();
    public GameObject rope;
    public int count = 0;
    public static Color32[] colors = new Color32[]
    {
        new Color32(31, 63, 224, 255),
        new Color32(248, 11, 11, 255),
        new Color32(15, 132, 0, 255),
        new Color32(245, 255, 0, 255)
    };

    private void Start()
    {
        tether = this.gameObject;
        rope.GetComponent<SpriteRenderer>().color = colors[PlayerPrefs.GetInt("Color")];
        int num = getCount((Vector2)player.transform.position, (Vector2)tether.transform.position);
        if (num < 2) num = 2;
        List<Vector2> ps = getPoints((Vector2)player.transform.position, (Vector2)tether.transform.position, num);
        for (int i = 0; i < ps.Count; i++)
        {
            GameObject go = Instantiate(rope);
            go.transform.parent = tether.transform;
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
        int num2 = getCount((Vector2)gos[^ 1].transform.TransformPoint(gos[^ 1].GetComponents<HingeJoint2D>()[0].anchor), (Vector2)tether.transform.position);
        for(int i = 0; i < gos.Count; i++)
        {
            if (gos[i].transform.position.x < tether.transform.position.x)
            {
                //Destroy(gos[i]);
                //gos.RemoveAt(i);
            }
        }
        if (num > count) 
        for(int i = 0; i < num - count; i++)
        {
            GameObject go = Instantiate(rope);
                go.transform.parent = tether.transform;
                gos[^1].GetComponents<HingeJoint2D>()[0].enabled = true;
            go.transform.position = (Vector2)gos[^1].transform.TransformPoint(gos[^1].GetComponents<HingeJoint2D>()[0].anchor) + go.GetComponent<HingeJoint2D>().anchor;
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
        return (int)Vector2.Distance(p, q);
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

    public void AddDistanceJoint(GameObject o, Rigidbody2D toAttach = null)
    {
        var j = o.AddComponent<DistanceJoint2D>();
        j.autoConfigureDistance = false;
        j.autoConfigureConnectedAnchor = false;
        j.maxDistanceOnly = true;
        j.distance = 0;
        j.anchor = Vector2.zero;
        
        if(toAttach != null)
        {
            j.connectedAnchor = toAttach.gameObject.transform.position;
            j.connectedBody = toAttach;
        }
        else
        {
            j.connectedAnchor = transform.position;
            
        }
    }
}