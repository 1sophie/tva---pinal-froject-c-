using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
#if UNITY_WSA
using UnityEngine.WSA;
#endif

public class player : MonoBehaviour
{
    public float speed = 25f;
    public float jumpForce = 10f;
    public bool jumpable = true;
    private Rigidbody2D rb;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    public int Health = 100;
    public Text HealthText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float v = Input.GetAxis("Horizontal");
        transform.Translate(v * speed * Time.deltaTime, 0, 0);


        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        jumpable = Physics2D.OverlapCircle(
       groundCheck.position,
       groundCheckRadius,
       groundLayer
   );

        if (jumpable && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }


        if(HealthText == null)
        {
            Debug.Log("help wher helt");
        }
        else
        {
            HealthText.text = "Health: " + Health;
            if (Health <= 0) 
            {
                Time.timeScale = 0f;
            }
        }

    }
    private void Jump()
    {
        if (jumpable)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(0f, -jumpForce), ForceMode2D.Impulse);
        }
    }
    
}
