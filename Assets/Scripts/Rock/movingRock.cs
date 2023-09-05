using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class movingRock : MonoBehaviour
{
    public float range = 4;
    public Vector2 startPosition;
    public float speed = 4;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (Vector2.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy1")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}