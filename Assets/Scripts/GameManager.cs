using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using NavMeshPlus.Components;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private BridgeSpot currentSpot;
    public LevelManager levelManager;

    public GameObject failureScreen;
    public GameObject completeScreen;
    public GameObject gameCompleteScreen;
    public GameObject canvas;
    public TutorialManager tutorialManager;

    public bool isCharacterActive;
    public bool isTutorialActive;
    //public NavMeshAgent agentPlayer;
    //public NavMeshAgent agentShip;
    //public NavMeshSurface surfacePlayer;
    //public NavMeshSurface surfaceShip;

    //private Vector3 target;

    public TextMeshProUGUI bridgeStockText;

    //public int[] bridgeStock;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            Destroy(canvas);
            Destroy(tutorialManager.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //agentPlayer.updateRotation = false;
        //agentPlayer.updateUpAxis = false;
        //agentShip.updateRotation = false;
        //agentShip.updateUpAxis = false;
        //surfacePlayer.UpdateNavMesh(surfacePlayer.navMeshData);
        //surfaceShip.UpdateNavMesh(surfaceShip.navMeshData);
        //UpdateBridgeStock();
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(tutorialManager.gameObject);
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    agentPlayer.SetDestination(new Vector3(target.x, target.y, agentPlayer.gameObject.transform.position.z));
        //}
        //Debug.Log(agentPlayer.pathStatus);
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
            if (levelManager.bridgeStock[bridgeType] > 0)
            {
                UpdateBridgeStock(bridgeType, -1);
                currentSpot.ActiveBridge = currentSpot.bridgeTypes[bridgeType];
                currentSpot.IsSelected = false;
                currentSpot = null;
                levelManager.UpdateNavMesh();
                //surfacePlayer.UpdateNavMesh(surfacePlayer.navMeshData);
                //surfaceShip.UpdateNavMesh(surfaceShip.navMeshData);                
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
        levelManager.bridgeStock[index] += change;
        bridgeStockText.text = levelManager.bridgeStock[1] + "\n" + levelManager.bridgeStock[2];
    }

    public void UpdateBridgeStock()
    {
    bridgeStockText.text = levelManager.bridgeStock[1] + "\n" + levelManager.bridgeStock[2];
    }

    public void StartCharacterPath()
    {
        if (tutorialManager.activePhase == TutorialManager.Phase.Phase1 || tutorialManager.activePhase == TutorialManager.Phase.Phase2)
        {
            return;
        }
        NavMeshPath path = new NavMeshPath();
        //Vector3 target = new Vector3(levelManager.goal.position.x, levelManager.goal.position.y, levelManager.agentPlayer.gameObject.transform.position.z);
        if (levelManager.requiresTorch == true)
        {
            levelManager.agentPlayer.CalculatePath(levelManager.torch.transform.position, path);
        }
        else
        {
            levelManager.agentPlayer.CalculatePath(levelManager.goal.position, path);
        }
        
        if (path.status == NavMeshPathStatus.PathPartial)
        {
            FailLevel();
        }
        levelManager.agentPlayer.SetPath(path);

        isCharacterActive = true;
        //Debug.Log(levelManager.agentPlayer.pathStatus);
        //if (levelManager.agentPlayer.pathStatus == NavMeshPathStatus.PathPartial)
        //{
        //    Debug.Log("Character cannot reach destination");
        //}
    }

    public void StartShipPath()
    {
        Debug.Log("Start Ship Path");
        NavMeshPath path = new NavMeshPath();
        levelManager.agentShip.CalculatePath(levelManager.goal.position, path);
        Debug.Log(path.status);
        if (path.status == NavMeshPathStatus.PathPartial)
        {
            FailLevel();
        }
        levelManager.agentShip.SetPath(path);
    }

    public void FailLevel()
    {
        if (!isTutorialActive)
        {
            failureScreen.SetActive(true);
        }
    }

    public void CompleteLevel()
    {
        tutorialManager.activePhase = TutorialManager.Phase.Phase9;
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 2)
        {
            completeScreen.SetActive(true);
        }
        else
        {
            gameCompleteScreen.SetActive(true);
        }
        
    }

    public void RestartLevel()
    {
        failureScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isCharacterActive = false;
        
    }

    public void GoToNextLevel()
    {
        completeScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        isCharacterActive = false;
    }

    public void GotoEndScreen()
    {
        Destroy(canvas);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
