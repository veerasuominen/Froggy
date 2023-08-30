using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer playerSprite;
    public Vector2 movement;
    public float movementSpeed = 5;
    public float sprintSpeed = 2;
    public bool sprinting;

    //health
    public int maxHealth = 5;
    public int currentHeath;
    public Health healthBar;

    //dashing
    public bool canDash;
    public bool isDashing;
    private Vector2 dashingDirection;
    private float dashCooldown = 2;
    private float dashingVelocity = 5;
    public TrailRenderer tr;

    public GameObject tongue;
    public Collider2D rangeCollider;
    public bool isInRange;
    public float tongueSpeed = 10;
    public bool arrowPressed;
    public Vector2 playerPosition;
    public Vector2 mousePosition;

    // Start is called before the first frame update
    private void Start()
    {
        currentHeath = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            TakeDamage(1);
        }
        //if (Input.GetKeyDown(KeyCode.Space) && canDash)
        //{
        //    isDashing = true;
        //    canDash = false;
        //    tr.emitting = true;
        //    dashingDirection = new Vector2(movement.x, movement.y);
        //    if (dashingDirection == Vector2.zero)
        //    {
        //        dashingDirection = new Vector2(transform.localScale.x, 0f);
        //    }
        //}

        movement.y = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");

        Movement();
        Rotation();

        //TongueGrapple();

        playerPosition = transform.position;
    }

    private void TakeDamage(int damage)
    {
        currentHeath -= damage;
        healthBar.SetHealth(currentHeath);
    }

    //public IEnumerator Dash()
    //{
    //    canDash = false;
    //    isDashing = true;
    //    float originalGravity = rb.gravityScale;
    //    rb.gravityScale = 0f;
    //    rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
    //    tr.emitting = true;
    //    yield return new WaitForSeconds(dashingTime);
    //    tr.emitting = false;
    //    rb.gravityScale = originalGravity;
    //    isDashing = false;

    //    yield return new WaitForSeconds(dashCooldown);
    //    canDash = true;
    //}

    private void Rotation()
    {
        if (Input.GetKeyDown(KeyCode.A) && transform.rotation != null)
        {
            transform.SetPositionAndRotation(transform.position, transform.rotation);
        }
        if (Input.GetKey(KeyCode.D))
        {
        }
    }

    private void Movement()
    {
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        /* rb.rotation = aimAngle;*/

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
            movementSpeed = movementSpeed + sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = 5;
            sprinting = false;
        }
    }
}