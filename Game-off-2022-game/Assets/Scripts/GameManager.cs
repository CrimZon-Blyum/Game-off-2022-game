using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool Dm = false;
    
    void Awake()
    {
        if (Application.isEditor)
        {
            Dm = true;
        }
    }

    
    void Update()
    {
        
    }
}
