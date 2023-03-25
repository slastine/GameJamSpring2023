using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeJoint : MonoBehaviour
{
    public Vector2 Pin;
    public Vector2 RemotePin;
    public GameObject Remote;

    void Start()
    {
        
    }

    public void UpdateSegment()
    {
        if (Remote != null)
        {
            var t1 = Transpose(RemotePin, Remote.transform) + (Vector2)Remote.transform.position;
            var t2 = Transpose(Pin, transform) + (Vector2)transform.position;
            var correction = t2 - t1;
            transform.position = (Vector2)transform.position - correction;
        }
    }

    Vector2 Transpose(Vector2 v1, Transform t) =>
        v1.x * t.right + v1.y * t.up;
}
