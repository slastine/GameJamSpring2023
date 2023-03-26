using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChainTest : MonoBehaviour
{
    public GameObject player;
    public GameObject tether;
    public int count = 1;

    private void Update()
    {
        Vector2 p = player.transform.position;
        Vector2 q = tether.transform.position;

        int temp = getCount(p, q);
        if (temp > count) Debug.Log("We need more points");
        count = temp;
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

}

