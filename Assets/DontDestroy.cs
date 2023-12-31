using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoy : MonoBehaviour
{
    private static GameObject savedObject = null;
    private void Awake()
    {
        if (savedObject)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            savedObject = gameObject;
        }
    }
}