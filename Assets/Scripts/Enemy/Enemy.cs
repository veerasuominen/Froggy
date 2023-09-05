using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float range = 8;
    public string turretsEnemy = "Player";
    public Rigidbody2D partToRotateRB;
    public GameObject partToRotate;
    public GameObject enemyBullet;
    public bool readyToShoot;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        readyToShoot = true;
    }

    private void Update()
    {
        if (target == null)
            return;

        Vector2 aimDirection = target.position - partToRotate.transform.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        partToRotateRB.MoveRotation(aimAngle);

        if (target != null && readyToShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(turretsEnemy);

        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    private IEnumerator Shoot()
    {
        readyToShoot = false;
        Instantiate(enemyBullet, partToRotate.transform.position, partToRotate.transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(enemyBullet, partToRotate.transform.position, partToRotate.transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(enemyBullet, partToRotate.transform.position, partToRotate.transform.rotation);
        yield return new WaitForSeconds(0.3f);
        Instantiate(enemyBullet, partToRotate.transform.position, partToRotate.transform.rotation);
        yield return new WaitForSeconds(3f);
        readyToShoot = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        Debug.Log("Collision detected");
        if (collision.gameObject.name == "Tongue")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}