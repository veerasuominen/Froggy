using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer playerSprite;
    public Vector2 movement;
    public float movementSpeed = 5;
    public float sprintSpeed = 2;
    public bool sprinting;

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
    }

    // Update is called once per frame
    private void Update()
    {
        movement.y = Input.GetAxis("Vertical");
        movement.x = Input.GetAxis("Horizontal");
        Movement();
        Rotation();
        //TongueGrapple();

        playerPosition = transform.position;
    }

    //private void TongueGrapple()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        arrowPressed = true;
    //        tongue.transform.Translate(0, tongueSpeed * Time.deltaTime, 0);
    //    }

    //}

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerSprite.flipX = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerSprite.flipX = true;
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