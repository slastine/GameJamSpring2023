using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectNodes : MonoBehaviour
{
    public GameObject player;
    public List<Node> connectedNodes = new List<Node>();
    public int nodesInScene;

    private void Start()
    {
        player.GetComponent<Player>().connectedTo = connectedNodes[0];
    }
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
                    player.transform.position += Vector3.right;
                    if (connectedNodes.Contains(node))
                    {
                        connectedNodes.Remove(node);
                        node.gizmo.Activate();
                        node.Deactivate();
                    }
                    else
                    {
                        connectedNodes.Add(node);
                        node.gizmo.Activate();
                        node.Activate();
                        ChainTest connect = player.GetComponent<Player>().connectedTo.gameObject.GetComponent<ChainTest>();
                        connect.AddDistanceJoint(connect.gos[0], node.gameObject.GetComponent<Rigidbody2D>());
                        connect.gos[0].GetComponents<HingeJoint2D>()[1].connectedBody = node.GetComponent<Rigidbody2D>();
                        connect.player = this.gameObject;
                        node.gameObject.AddComponent<ChainTest>().player = this.player;
                        node.gameObject.GetComponent<ChainTest>().rope = connect.rope;
                        player.GetComponent<Player>().connectedTo = node;
                    }
                }

            }
        }
    }

    public bool canWin()
    {
        return connectedNodes.Count >= nodesInScene;
    }
}
