using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueSpawner : MonoBehaviour
{
    public GameObject tonguePrefab;
    public Rigidbody2D rb;
    public Vector2 mousePosition;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.MoveRotation(aimAngle);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(tonguePrefab, transform.position, transform.rotation);
        }
    }
}