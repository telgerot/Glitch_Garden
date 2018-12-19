using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

float currentSpeed = 1f;
    GameObject currentTarget;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
    }	

	void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime );
	}

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;        
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("IsAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
        }
    }
}
