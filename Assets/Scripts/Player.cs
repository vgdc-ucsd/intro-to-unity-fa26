using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpStrength = 5;
    public float groundedCheckDistance = 0.5f;

    private bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundedCheckDistance, LayerMask.GetMask("Ground"));

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isDead)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Obsctacle.moveSpeed = 0f;
            ObstacleSpawner.doesSpawning = false;
            isDead = true;
        }
    }
}
