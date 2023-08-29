using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    public float range = 10;
    public Vector2 startPosition;

    // Start is called before the first frame update
    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up);

        if (Vector2.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }
}