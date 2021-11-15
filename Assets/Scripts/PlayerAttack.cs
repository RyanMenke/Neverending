using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack 
{
    private int damage;

    public float attackDuration = 0f;

    public bool attack1IsActive = false;
    public bool attack2IsActive = false;
    public bool attack3IsActive = false;
    public bool isAttacking = false;

    public void BasicAttack()
    {
        if (attackDuration > 0)
        {
            attackDuration = attackDuration -= Time.deltaTime;
        }

        if (attack1IsActive || attack2IsActive || attack3IsActive)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            attack1IsActive = true;
            attackDuration = 1.2f;
        }
        else if (Input.GetMouseButtonDown(0) && attack1IsActive)
        {
            attack2IsActive = true;
            attack1IsActive = false;
            attackDuration = 1.2f;
        }
        else if (Input.GetMouseButtonDown(0) && attack2IsActive)
        {
            attack3IsActive = true;
            attack2IsActive = false;
            attackDuration = 1.2f;
        }

        if (attackDuration <= 0f)
        {
            attack1IsActive = false;
            attack2IsActive = false;
            attack3IsActive = false;
        }
    }
}
