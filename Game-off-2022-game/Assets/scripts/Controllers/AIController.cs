using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "inputController/AIController")]

public class AIController : InputController
{
    public override bool RetrieveJumpInput()
    {
        return true;
    }

    public override float RetrieveMoveInput()
    {
        return 1f;
    }

    public override bool RetrieveCrouchInput()
    {
        return false;
    }

    public override bool RetrieveUncrouchInput()
    {
        return false;
    }
}
