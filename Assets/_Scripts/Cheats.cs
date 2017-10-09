#if (UNITY_EDITOR) 
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cheats : MonoBehaviour
{

    [MenuItem("Cheats/Reset Lives")]
    public static void ResetLives()
    {
        if (Application.isPlaying)
        {
            FindObjectOfType<GameManager>().LivesAmount = 5;
        }
        else
        {
            Debug.LogError("Not in play mode.");
        }
    }
    [MenuItem("Cheats/Suicide")]
    public static void Kill()
    {
        if (Application.isPlaying)
        {
            FindObjectOfType<GameManager>().PlayerDeath();
        }
        else
        {
            Debug.LogError("Not in play mode.");
        }
    }
    
}
#endif