using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float projectileDamage = 50f;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>(); //sets a variable to enemy's health
        var attacker = otherCollider.GetComponent<Attacker>(); //sets a variable to enemy's health

        if(attacker && health) //checks to see if the projectile is hitting an actual enemy that has health (otherwise passes through)
        {
            health.DealDamage(projectileDamage); //does projectile damage to enemy's health
            Destroy(gameObject); //gets rid of the projectile after it hits an enemy
        }
    }
}
