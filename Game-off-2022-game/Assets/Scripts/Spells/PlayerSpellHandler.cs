using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSpellHandler : MonoBehaviour
{
    public GameObject[] EquipedSpells;
    public GameObject ActiveSpell = null;
    
    // Start is called before the first frame update
    void Start()
    {
        if (ActiveSpell == null)
        {
            ActiveSpell = EquipedSpells[0];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q") && GameManager.Dm)
        {
            
        }
    }
}
