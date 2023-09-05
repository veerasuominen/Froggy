using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    public float speed;
    public float range = 4;
    public Vector2 startPosition;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Rock collision detected");
            Destroy(gameObject);
        }
    }

    public void Move()
    {
        transform.Translate(Vector3.up);
    }
}