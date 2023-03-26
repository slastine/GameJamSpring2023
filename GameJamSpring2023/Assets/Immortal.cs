using UnityEngine;
using UnityEngine.SceneManagement;

public class Immortal : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
