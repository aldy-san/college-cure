using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator am;
    PlayerMovement pm;
    SpriteRenderer sr;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        am.runtimeAnimatorController = gameManager.currentCharacterData.animation;
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0)
        {
            am.SetBool("Move", true);
        } else
        {
            am.SetBool("Move", false);
        }
        SpriteDirection();
    }
    void SpriteDirection()
    {
        if (pm.shootDir.x < 0)
        {
            sr.flipX = true;
        } else if (pm.shootDir.x > 0)
        {
            sr.flipX = false;
        }
    }
}
