using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private BridgeSpot currentSpot;

    public TextMeshProUGUI bridgeStockText;

    public int[] bridgeStock;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        bridgeStockText.text = "Solid bridges: " + bridgeStock[1] + "\nWeak bridges: " + bridgeStock[2];
    }

    private void Start()
    {

    }

    public void SelectBridgeSpot(BridgeSpot spot)
    {
        if (currentSpot != null)
        {
            currentSpot.IsSelected = false;
        }

        spot.IsSelected = true;

        currentSpot = spot;
    }

    public void PlaceBridge(int bridgeType)
    {
        if (bridgeStock[bridgeType] > 0)
        {
            updateBridgeStock(bridgeType, -1);
            currentSpot.ActiveBridge = currentSpot.bridgeTypes[bridgeType];
            currentSpot.IsSelected = false;
            currentSpot = null;
        } else
        {
            Debug.Log("Not enough bridges of that type left");
        }
    }

    public void updateBridgeStock(int index, int change)
    {
        bridgeStock[index] += change;
        bridgeStockText.text = "Solid bridges: " + bridgeStock[1] + "\nWeak bridges: " + bridgeStock[2];
    }
}
