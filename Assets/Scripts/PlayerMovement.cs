using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MoveInput();
    }

    void MoveInput()
    {
        float _x = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(_x * speed, rigidBody.velocity.y);
    }
}
