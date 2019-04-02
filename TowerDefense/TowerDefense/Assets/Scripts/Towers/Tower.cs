using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int damage = 10;
    public float attackRate = 1f;
    public float attackRange = 2f;

    protected Enemy currentEnemy;

    private float attackTimer = 0f;

    private void OnDrawGizmosSelected()
    {
        // Draw the attack sphere around Tower
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    // Aims at a given enemy every frame
    public virtual void Aim(Enemy e)
    {
        print("I am aiming at '" + e.name + "'");
    }

    // Attacks at a given enemy only when 'attacking'
    public virtual void Attack(Enemy e)
    {
        print("I am attacking '" + e.name + "'");
    }

    void DetectEnemies()
    {
        // Reset current enemy
        currentEnemy = null;

        // Perform OverlapSphere
        Collider[] hits = Physics.OverlapSphere(transform.position, attackRange);
        foreach (var hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy)
            {
                // Set current enemy to that one
                currentEnemy = enemy;
            }           
        }
    }

    // Protected - Accessible to Cannon / Other tower classes
    // Virtual - Able to change what this function does in derived classes
    protected virtual void Update()
    {
        // Count up the timer
        attackTimer += Time.deltaTime;
        // If there's an enemy
        if (currentEnemy)
        {
            // Aim at the enemy
            Aim(currentEnemy);
            // Is attack timer ready?
            if(attackTimer >= attackRate)
            {
                // Attack the enemy!
                Attack(currentEnemy);
                // Reset timer
                attackTimer = 0f;
            }
        }
    }
}
