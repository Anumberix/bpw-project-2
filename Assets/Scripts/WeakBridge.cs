using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakBridge : MonoBehaviour
{
    private BoxCollider2D bridgeCollider;
    // Start is called before the first frame update
    void Start()
    {
        bridgeCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bridgeCollider.enabled = GameManager.Instance.isCharacterActive; // if player pressed go enable collider
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.levelManager.UpdateNavMesh(); // Update Nav Mesh after bridge is gone
        }
    }
}
