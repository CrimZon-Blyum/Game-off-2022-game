using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassThruPlatform : MonoBehaviour
{

    private Collider2D _collider;
    private bool _playerOnPlatform;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        _collider.enabled = true;
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        var player = other.gameObject.GetComponent<IsPlayer>();
        var player_coll = other.gameObject.GetComponent<BoxCollider2D>();
        if (player != null)
        {
            _playerOnPlatform = value;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }
}
