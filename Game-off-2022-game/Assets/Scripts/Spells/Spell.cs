using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : ScriptableObject
{
    public abstract int Damage();
    public abstract string D_Type();

    public abstract void Activate();
}
