using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnim : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("Die");
        }

    }
}
