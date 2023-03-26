using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterFall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rope"))
            SceneManager.LoadScene("Game Over");
            //foreach (var v in GameObject.FindGameObjectsWithTag("Rope"))
            //    Destroy(v);
    }
}
