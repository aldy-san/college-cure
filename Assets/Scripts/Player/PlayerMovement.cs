using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 moveDir;
    public Vector2 shootDir;

    Rigidbody2D rb;
    CharacterScriptableObject characterData;
    GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        characterData = gameManager.currentCharacterData;
        shootDir = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }
     void FixedUpdate()
    {
        Move();
    }
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
        if (!Input.GetKey(KeyCode.L) && (moveX != 0 || moveY != 0))
        {
            shootDir = moveDir;
        }

    }
    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * characterData.moveSpeed, moveDir.y * characterData.moveSpeed);
    }
}
