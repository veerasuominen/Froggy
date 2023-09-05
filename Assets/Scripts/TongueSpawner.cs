using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSpawner : MonoBehaviour
{
    [Header("Assignables")]
    public GameObject tonguePrefab;

    public GameObject snakePrefab;
    public Rigidbody2D rb;
    public UIcontroller controller;

    [Header("Floats and Vector")]
    public Vector2 mousePosition;
    public float cooldown = 0.5f;
    public float snakeShotTimes = 0;

    [Header("Bools")]
    public bool readyToShoot;
    public bool shotSnake;

    [Header("Rock")]
    public RockProjectile rockScript;
    public GameObject rockPrefab;
    public bool shotRock;
    public float rockShotTimes = 0;

    // Start is called before the first frame update
    private void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(aimAngle);

        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToShoot == true)
        {
            StartCoroutine(ShootTongue());
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && controller.rockEaten == true && shotRock == false)
        {
            readyToShoot = false;
            ShootRock();
            readyToShoot = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && controller.enemyEaten == true && shotSnake == false && controller.bothDestroyed == false)
        {
            readyToShoot = false;
            ShootSnake();
            readyToShoot = true;
        }
    }

    private void ShootSnake()
    {
        Instantiate(snakePrefab, transform.position, transform.rotation);
        shotSnake = true;

        snakeShotTimes++;
    }

    private void ShootRock()
    {
        Instantiate(rockPrefab, transform.position, transform.rotation);

        shotRock = true;
        rockShotTimes++;
    }

    private IEnumerator ShootTongue()
    {
        readyToShoot = false;
        Instantiate(tonguePrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(cooldown);
        readyToShoot = true;
    }
}