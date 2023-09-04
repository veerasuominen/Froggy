using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSpawner : MonoBehaviour
{
    public GameObject tonguePrefab;
    public GameObject rockPrefab;
    public GameObject snakePrefab;
    public Rigidbody2D rb;
    public Vector2 mousePosition;
    public UIcontroller controller;

    public float cooldown = 0.3f;
    public bool readyToShoot;
    public bool shotSnake;
    public float snakeShotTimes = 0;

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

        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToShoot == true && controller.enemyEaten == false)
        {
            StartCoroutine(ShootTongue());
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && snakeShotTimes == 1)
        {
            StartCoroutine(ShootTongue());
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && controller.enemyEaten == true && shotSnake == false)
        {
            ShootSnake();
        }
    }

    private void ShootSnake()
    {
        Instantiate(snakePrefab, transform.position, transform.rotation);
        shotSnake = true;

        snakeShotTimes++;
    }

    private IEnumerator ShootTongue()
    {
        readyToShoot = false;
        Instantiate(tonguePrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(cooldown);
        readyToShoot = true;
    }
}