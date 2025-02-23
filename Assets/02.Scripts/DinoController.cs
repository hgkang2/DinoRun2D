using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce;
    bool isGround;
    bool isDown;

    private Animator anim;
    private Rigidbody2D rb;

    public Transform groundCheckPoint;  // ���� ���� ��ġ
    public LayerMask whatIsGround;   // Ground���� ���� LayerMask


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isGround", true);
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);
        if(Input.GetKeyDown(KeyCode.Space) && isGround.Equals(true))
        {
            rb.velocity = new Vector2(rb.velocity.x , jumpForce);
        }
        anim.SetBool("isGround", isGround);
    }
}
