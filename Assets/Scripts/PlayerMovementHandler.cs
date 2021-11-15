using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHandler : MonoBehaviour
{
    public PlayerAttack attack;
    public Player player;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        attack = new PlayerAttack();
        player = new Player();
        player.body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Ground")
        {
            player.TouchingGround();
        }
    }

    private void OnCollisionExit2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Ground")
        {
            player.LeavingGround();
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isAttacking", attack.isAttacking);
        animator.SetBool("Attack1", attack.attack1IsActive);
        animator.SetBool("Attack2", attack.attack2IsActive);
        animator.SetBool("Attack3", attack.attack3IsActive);
        attack.BasicAttack();
        player.MovementHandler();
        player.JumpHandler();
    }

    public void FixedUpdate()
    {
        player.body.velocity = new Vector2(player.horizontal * player.runSpeed, player.jumpComponent);
    }
}
