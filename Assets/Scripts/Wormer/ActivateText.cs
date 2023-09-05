using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateText : MonoBehaviour
{
    public GameObject textBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textBox.SetActive(false);
    }
}