using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    [SerializeField] private Vector2 pushVector = Vector2.left;
    private Rigidbody2D playerRigidbody = null;
    private void FixedUpdate()
    {
        if (playerRigidbody)  // != null)
        {
            playerRigidbody.velocity += pushVector;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRigidbody = collision.GetComponent<Rigidbody2D>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRigidbody = null;
        }
    }
}
