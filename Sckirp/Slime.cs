using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Vector2 PlayerPos;
    public float forceAmount = 5f;
    private bool jumping;
    private Rigidbody2D rb;
    public Transform player;
    public GameObject playerposnt;
    Animator animator;

    int health = 100;

    
    void Start()
    {
        playerposnt = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Jumpy", 1f, 2f);

        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        
    }
    void Jumpy()
    {

        animator.SetTrigger("Jump");
        StartCoroutine(JumpDelay());
    }

    IEnumerator JumpDelay()
    {
        yield return new
        WaitForSeconds(0.3f); //delay

        rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        Vector2 direction = ((Vector2)player.position - rb.position).normalized;

        rb.AddForce(direction * forceAmount, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            player playerScript = collision.gameObject.GetComponent<player>();
            playerScript.Health -= 10;
            
            
            
            Vector2 direction = ((Vector2)player.position - rb.position).normalized;

            rb.AddForce(-direction * forceAmount * 2, ForceMode2D.Impulse);
        }
    }
}
