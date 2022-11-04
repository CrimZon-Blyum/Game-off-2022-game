using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField] private BoxCollider2D normal_collider = null;
    [SerializeField] private EdgeCollider2D normal_Ecollider = null;
    [SerializeField] private GameObject normal = null;
    [SerializeField] private GameObject crouch = null;

    private bool desiredCrouch;
    private bool desiredUncrouch;
    private Ground ground;
    private bool onGround;

    void Awake()
    {
        ground = GetComponent<Ground>();
    }

    void Update()
    {
        desiredCrouch |= input.RetrieveCrouchInput();
        desiredUncrouch |= input.RetrieveUncrouchInput();
    }

    private void FixedUpdate()
    {
        onGround = ground.GetOnGround();
        if (desiredCrouch )
        {
            if (onGround)
            {
                CrouchAction();
            }
            desiredCrouch = false;
        }
        if (desiredUncrouch || input.RetrieveJumpInput())
        {
            Uncrouch();
            desiredUncrouch = false;
        }

        
    }

    private void Uncrouch()
    {
        normal.SetActive(true);
        normal_collider.enabled = true;
        crouch.SetActive(false);
        normal_Ecollider.enabled = true;
    }

    private void CrouchAction()
    {
        crouch.SetActive(true);
        normal.SetActive(false);
        normal_collider.enabled = false;
        normal_Ecollider.enabled = false;
    }



}
