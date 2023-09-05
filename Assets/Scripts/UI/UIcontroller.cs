using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    public bool enemyEaten;
    public bool rockEaten;
    public bool bothDestroyed;
    public GameObject enemy;
    public GameObject rock;
    public GameObject enemyInInventory;
    public GameObject rockInInventory;
    public TongueSpawner spawner;

    // Start is called before the first frame update
    private void Start()
    {
        enemyEaten = false;
        rockEaten = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (enemy == null && rock == null)
        {
            bothDestroyed = true;

            rockInInventory.SetActive(false);
            enemyInInventory.SetActive(false);
        }
        else if (rock == null)
        {
            rockEaten = true;
            rockInInventory.SetActive(true);
        }

        if (spawner.rockShotTimes == 1)
        {
            rockInInventory.SetActive(false);
        }
        else if (enemy == null)
        {
            enemyEaten = true;
            enemyInInventory.SetActive(true);
        }

        if (spawner.snakeShotTimes == 1)
        {
            enemyInInventory.SetActive(false);
        }
    }
}