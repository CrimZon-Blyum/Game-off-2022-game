using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField] private BoxCollider2D normal_collider = null;
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
        if (desiredUncrouch || !onGround)
        {
            UncrouchAction();
            desiredUncrouch = false;
        }

        
    }

    private void CrouchAction()
    {
        normal.SetActive(false);
        normal_collider.enabled = false;
        crouch.SetActive(true);
    }

    private void UncrouchAction()
    {
        normal.SetActive(true);
        normal_collider.enabled = true;
        crouch.SetActive(false);
    }

}
