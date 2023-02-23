using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private BridgeSpot currentSpot;

    [SerializeField] private GameObject solidBridgePrefab;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

    }

    public void SelectBridgeSpot(BridgeSpot spot)
    {
        if (currentSpot != null)
        {
            currentSpot.isSelected = false;
            currentSpot.setIndicator(false);
        }

        spot.isSelected = true;
        spot.setIndicator(true);

        currentSpot = spot;
    }

    public void PlaceBridge()
    {
        if (currentSpot.bridgePlaced == false)
        {
            Instantiate(solidBridgePrefab, currentSpot.gameObject.transform);
            currentSpot.indicator.SetActive(false);
            currentSpot.areaIndicator.SetActive(false);
            currentSpot.bridgePlaced = true;
        }
    }
}
