using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Tube : MonoBehaviour
{

    public ConnectNodes nodes;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        nodes = player.GetComponent<ConnectNodes>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(nodes.canWin())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
