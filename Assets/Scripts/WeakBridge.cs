using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakBridge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            gameObject.SetActive(false);
            Debug.Log("aaaaaaaaaaaa");
        }
    }
}
