using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerController",menuName ="inputController/PlayerController")]

public class PlayerController : InputController
{
    public override bool RetrieveJumpInput()
    {
        return Input.GetButtonDown("Jump");
    }

    public override float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override bool RetrieveCrouchInput()
    {
        return Input.GetButtonDown("Crouch");
    }
    public override bool RetrieveUncrouchInput()
    {
        return Input.GetButtonUp("Crouch");
    }
}
