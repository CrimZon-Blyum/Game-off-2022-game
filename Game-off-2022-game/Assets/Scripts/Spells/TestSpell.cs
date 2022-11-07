using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TestSpell : Spell
{
    int i = 1;
    public override int RetreiveDamage()
    {
        i += 1;
        return i;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
