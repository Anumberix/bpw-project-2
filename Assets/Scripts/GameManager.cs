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
    public TutorialManager tutorialManager;
    public LevelManager levelManager;
    private BridgeSpot currentSpot;

    public GameObject failureScreen;
    public GameObject completeScreen;
    public GameObject gameCompleteScreen;
    public GameObject canvas;

    public bool isCharacterActive;
    public bool isTutorialActive;

    public TextMeshProUGUI bridgeStockText;

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
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(tutorialManager.gameObject);
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
