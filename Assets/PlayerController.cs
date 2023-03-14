using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 25.0f;
    public float horizontalInput;
    public float forwardInput;
    public float jumpForce = 10.0f;
    public bool canJump = true;

    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
      playerRb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
      Move();
      Jump();
    }

    void Move()
    {
      float horizontalMovement = Input.GetAxis("Horizontal");
      float verticalMovement = Input.GetAxis("Vertical");
      float movementForce = speed * horizontalMovement;
      // horizontalInput = Input.GetKeyDown(KeyCode.A) ? -1 : Input.GetKeyDown(KeyCode.D) ? 1 : 0;
      // forwardInput = Input.GetKeyDown(KeyCode.W) ? 1 : Input.GetKeyDown(KeyCode.S) ? -1 : 0;
      // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
      // transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

      playerRb.AddForce(Vector2.right * movementForce, ForceMode2D.Impulse);
    }

    void Jump()
    {
      if (Input.GetKeyDown(KeyCode.Space) && canJump)
      {
        playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        canJump = false;
      }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      canJump = true;if (collision.gameObject.CompareTag("Ground"))
      {
        canJump = true;
      }
    }
}
