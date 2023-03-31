using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            GameManager.Instance.levelManager.requiresTorch = false;
            GameManager.Instance.StartCharacterPath();
            Destroy(gameObject);
        }

    }
}
