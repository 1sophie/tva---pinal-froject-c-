using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animatpr : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("WalkinLeft", true);
        }
        else
        {
            animator.SetBool("WalkinLeft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walkinright", true);
        }
        else
        {
            animator.SetBool("Walkinright", false);
        }
    }
}
