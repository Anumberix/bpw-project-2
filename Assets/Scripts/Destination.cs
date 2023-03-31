using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            GameManager.Instance.StartShipPath();
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Ship"))
        {
            GameManager.Instance.CompleteLevel();
        }
    }
}
