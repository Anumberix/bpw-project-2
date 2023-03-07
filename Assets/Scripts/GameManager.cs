using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using NavMeshPlus.Components;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private BridgeSpot currentSpot;

    public NavMeshAgent agent;
    public NavMeshSurface Surface2D;

    private Vector3 target;

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
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = agent.gameObject.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        }

        agent.SetDestination(new Vector3(target.x, target.y, agent.gameObject.transform.position.z));
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
        if (currentSpot != null)
        {
            if (bridgeStock[bridgeType] > 0)
            {
                UpdateBridgeStock(bridgeType, -1);
                currentSpot.ActiveBridge = currentSpot.bridgeTypes[bridgeType];
                currentSpot.IsSelected = false;
                currentSpot = null;
                Surface2D.UpdateNavMesh(Surface2D.navMeshData);
                Debug.Log("yUP");
            }
            else
            {
                Debug.Log("Not enough bridges of that type left");
            }
        }
        else
        {
                Debug.Log("No bridge spot selected");

        }
    }

    public void UpdateBridgeStock(int index, int change)
    {
        bridgeStock[index] += change;
        bridgeStockText.text = "Solid bridges: " + bridgeStock[1] + "\nWeak bridges: " + bridgeStock[2];
    }
}
