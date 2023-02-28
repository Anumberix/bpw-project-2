using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSpot : MonoBehaviour
{
    [SerializeField] public GameObject indicator;
    [SerializeField] private GameObject activeBridge;
    public GameObject ActiveBridge
    {
        get { return activeBridge; }
        set
        {

            activeBridge.SetActive(false);


            value.SetActive(true);
            activeBridge = value;
        }
    }
    public GameObject[] bridgeTypes;

    [SerializeField] private bool isSelected = false;
    [SerializeField]
    public bool IsSelected
    {
        get { return isSelected; }
        set
        {
            indicator.SetActive(value);

            isSelected = value;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        activeBridge = bridgeTypes[0];
    }

    private void OnMouseDown()
    {
        GameManager.Instance.SelectBridgeSpot(this);
        Debug.Log("Clicked!");
    }

    public void setIndicator(bool status)
    {
        indicator.SetActive(status);
    }
}
