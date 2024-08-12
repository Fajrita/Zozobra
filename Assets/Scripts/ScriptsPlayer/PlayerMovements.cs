using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private float vel = 5f;
    public float baseVel;
    public float direction = 0f;
    public Rigidbody2D rb;

    public float salto = 5f;
    public LayerMask layerSuelo;

    public float dashF;
    public float dashT;
    private bool isDashing = false;

    private Animator animator;

    void Start()
    {
        vel = baseVel;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        

        RaycastHit2D enSuelo = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, layerSuelo);

        animator.SetBool("Suelo", enSuelo);
        Movim();
        if(rb.velocity.x != 0) animator.SetBool("movx", true);
        else animator.SetBool("movx", false);

        if (enSuelo)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }
        if(!enSuelo && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y - (1f * Time.deltaTime)));
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction * vel, rb.velocity.y);
    }

    private void Movim()
    {
        direction = Input.GetAxisRaw("Horizontal");
        if (direction < 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }
        else if (direction > 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }

        //solo por que aun no esta implementado para la build

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    if (!isDashing)
        //    {
        //        StartCoroutine(Dash());
        //    }
        //}
    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, salto);
    }

    IEnumerator Dash()
    {
        isDashing = true;
        vel *= dashF;
        yield return new WaitForSeconds(dashT);
        vel = baseVel;
        isDashing = false;
    }
}

