using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        Attacker attacker = GetComponent<Attacker>();
        Animator animator = GetComponent<Animator>();

        if (otherObject.GetComponent<Gravestone>())
        {
            animator.SetTrigger("jumpTrigger");
        }
        else if (otherObject.GetComponent<Defender>())
        {
            attacker.Attack(otherObject);
        }
    }
    
}
