using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpot : MonoBehaviour
{
    [SerializeField] public bool isSelected = false;
    [SerializeField] public bool bridgePlaced = false;
    [SerializeField] public GameObject indicator;
    [SerializeField] public GameObject areaIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameManager.Instance.SelectBridgeSpot(this);
    }

    public void setIndicator(bool status)
    {
        indicator.SetActive(status);
    }
}
