using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontroller : MonoBehaviour
{
    public bool enemyEaten;
    public GameObject enemy;
    public GameObject enemyInInventory;
    public TongueSpawner spawner;

    // Start is called before the first frame update
    private void Start()
    {
        enemyEaten = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (enemy == null)
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