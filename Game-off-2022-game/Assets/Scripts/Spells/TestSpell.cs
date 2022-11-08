using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class TestSpell : MonoBehaviour
{
    public GameObject GameObject;

    public void Activate()
    {
        GameObject Player = GameObject.Find("Character");
        Instantiate(GameObject, Player.transform.position, Player.transform.rotation);
    }

}
