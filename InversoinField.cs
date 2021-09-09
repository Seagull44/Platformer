using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InversoinField : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            Player.Inversion = true;
            Player.isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit"))
        {
            Player.Inversion = false;
            Player.isGrounded = false;
        }
    }
}
