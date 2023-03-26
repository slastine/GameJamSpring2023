using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectNodes : MonoBehaviour
{
    public GameObject player;
    public List<Node> connectedNodes = new List<Node>();
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D[] colliders = Physics2D.CircleCastAll(player.transform.position, 1f, new Vector2(1, 1));
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].collider.gameObject.GetComponent<Node>() != null)
                {
                    Node node = colliders[i].collider.gameObject.GetComponent<Node>();
                    if (connectedNodes.Contains(node))
                    {
                        connectedNodes.Remove(node);
                        node.gizmo.Activate();
                    }
                    else
                    {
                        connectedNodes.Add(node);
                        node.gizmo.Activate();
                    }
                }

            }
        }
    }
}
