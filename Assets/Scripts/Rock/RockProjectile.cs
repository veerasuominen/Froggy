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

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up);

        if (Vector2.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }
}