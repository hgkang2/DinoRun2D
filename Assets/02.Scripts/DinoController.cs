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

    //boxcollider offset �� size �� ������ ����
    
    private Vector2 savedOffset;
    private Vector2 savedSize;

    //boxcollider2D�� �����ϱ� ���� ����
    private BoxCollider2D boxCollider;


    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isGround", true);
        SaveColliderSettings();
        
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround.Equals(true) && isDown.Equals(false))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGround.Equals(true))
        {
            SetDownArrowDown();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && isGround.Equals(true))
        {
            SetDownArrowUp();
        }
            
        anim.SetBool("isGround", isGround);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.2f);
    }

    void SaveColliderSettings()
    {
        savedOffset = boxCollider.offset;
        savedSize = boxCollider.size;
    }
    void LoadColliderSettings()
    {
        boxCollider.offset = savedOffset;
        boxCollider.size = savedSize;
    }
    void SetDinoDownSetting()
    {
        boxCollider.offset = new Vector2(0, -0.25f);
        boxCollider.size = new Vector2(1.39f, 0.76f);
    }
    void SetDownArrowDown()
    {
        isDown = true;
        anim.SetBool("isDown", true);
        SetDinoDownSetting();
    }
    void SetDownArrowUp()
    {
        isDown = false;
        anim.SetBool("isDown", false);
        LoadColliderSettings();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("���� �浹�ߴ�");
    }
}
