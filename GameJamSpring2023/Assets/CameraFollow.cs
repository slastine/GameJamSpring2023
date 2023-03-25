using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera cam;
    public Player player;
    public float minX = 0;
    public float maxX = 100;
    public float minY = 0;
    public float maxY = 100;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(player.transform.position);
        if (viewportPoint.x < .3f)
        {
            cam.transform.Translate(Vector3.right *Time.deltaTime * -15);
        }
        if (viewportPoint.x > .7f)
        {
            cam.transform.Translate(Vector3.right * Time.deltaTime * 15);
        }
        if (viewportPoint.y < .3f)
        {
            cam.transform.Translate(Vector3.up * Time.deltaTime * -15);
        }
        if (viewportPoint.y > .7f)
        {
            cam.transform.Translate(Vector3.up * Time.deltaTime * 15);
        }
        if (cam.transform.position.x < minX) cam.transform.position = new Vector3(minX, cam.transform.position.y, -10) ;
        if (cam.transform.position.y  < minY) cam.transform.position = new Vector3(cam.transform.position.x, minY, -10);
    }
}
