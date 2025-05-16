using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            // Handle collision with enemy
            Debug.Log("Collided with coin!");
        }
    }
}
