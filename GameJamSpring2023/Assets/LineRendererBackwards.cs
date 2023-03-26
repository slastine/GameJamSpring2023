using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LineRendererBackwards : MonoBehaviour
{
    public TrailRenderer trail;
    public GameObject player;
    private void Update()
    {
        for(int i = 0; i < trail.positionCount; i++)
        {
            if ((Vector2.Distance(player.transform.position, trail.GetPosition(i)) < 5) && !player.GetComponent<Player>().animator.GetBool("isMovingRight"))
            {
                Vector3[] posList = new Vector3[trail.positionCount];
                Debug.Log(posList.Length);
                trail.GetPositions(posList);
                trail.Clear();
                List<Vector3> list = posList.ToList();
                list.RemoveAt(i);
                trail.AddPositions(list.ToArray());
            }
        }
    }
}
