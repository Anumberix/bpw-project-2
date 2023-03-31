using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public enum Phase { Phase1, Phase2, Phase3, Phase4, Phase5, Phase6, Phase7, Phase8, Phase9 }
    public Phase activePhase;

    //private GameObject player;
    //private GameManager gameManager;

    //public GameObject enemy;
    //public GameObject powerUp;

    public BridgeSpot[] bridgeSpots;

    public TextMeshProUGUI[] tutorialTexts;
    public GameObject tutorialText;

    //private bool phaseSetUp;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isTutorialActive)
        {
            UpdatePhase();
        }
    }

    void UpdatePhase()
    {
        switch (activePhase)
        {
            case Phase.Phase1:
                Phase1Behaviour();
                break;
            case Phase.Phase2:
                Phase2Behaviour();
                break;
            case Phase.Phase3:
                Phase3Behaviour();
                break;
            case Phase.Phase4:
                Phase4Behaviour();
                break;
            case Phase.Phase5:
                Phase5Behaviour();
                break;
            case Phase.Phase6:
                Phase6Behaviour();
                break;
            case Phase.Phase7:
                Phase7Behaviour();
                break;
            case Phase.Phase8:
                Phase8Behaviour();
                break;
            case Phase.Phase9:
                Phase9Behaviour();
                break;
        }
    }

    void Phase1Behaviour()
    {
        tutorialTexts[0].gameObject.SetActive(true);
        if (Input.GetMouseButtonDown(0))
        {
            activePhase = Phase.Phase2;
        }
        //if (Vector3.Distance(player.transform.position, new Vector3(0, 1, 0)) > 0.1f)
        //{
        //    StartCoroutine(PhaseEndRoutine());
        //}

    }

    void Phase2Behaviour()
    {
        tutorialTexts[0].gameObject.SetActive(false);
        tutorialTexts[1].gameObject.SetActive(true);

        if (bridgeSpots[0].IsSelected)
        {
            activePhase = Phase.Phase3;
        }
        //if (!phaseSetUp)
        //{
        //    player.transform.position = new Vector3(0, 1, 0);
        //    SpawnEnemies();
        //    phaseSetUp = true;
        //}

        //if (GameObject.FindWithTag("Enemy") == null)
        //{
        //    activePhase = Phase.Phase3;
        //    phaseSetUp = false;
        //}

    }

    void Phase3Behaviour()
    {
        tutorialTexts[1].gameObject.SetActive(false);
        tutorialTexts[2].gameObject.SetActive(true);

        if (bridgeSpots[0].ActiveBridge == bridgeSpots[0].bridgeTypes[1])
        {
            activePhase = Phase.Phase4;
        }
        //if (!phaseSetUp)
        //{
        //    player.transform.position = new Vector3(0, 1, 0);
        //    SpawnEnemies();
        //    phaseSetUp = true;
        //}

        //if (GameObject.FindWithTag("Enemy") == null)
        //{
        //    activePhase = Phase.Phase4;
        //    phaseSetUp = false;
        //}
    }

    void Phase4Behaviour()
    {
        tutorialTexts[2].gameObject.SetActive(false);
        tutorialTexts[3].gameObject.SetActive(true);

        bool phaseClear = true;

        foreach (BridgeSpot bridgeSpot in bridgeSpots)
        {
            if (bridgeSpot.ActiveBridge == bridgeSpot.bridgeTypes[0])
            {
                phaseClear = false;
            }
        }

        if (phaseClear)
        {
            activePhase = Phase.Phase5;
        }
        //if (bridgeSpot1.ActiveBridge != bridgeSpot1.bridgeTypes[0])
        //if (!phaseSetUp)
        //{
        //    player.transform.position = new Vector3(0, 1, 0);
        //    SpawnEnemies();
        //    Instantiate(powerUp, new Vector3(0, 1, 2.5f), powerUp.transform.rotation);
        //    phaseSetUp = true;
        //}

        //if (GameObject.FindWithTag("Enemy") == null)
        //{
        //    gameManager.TutorialCompleted();
        //    tutorialText[3].gameObject.SetActive(false);
        //}
    }

    void Phase5Behaviour()
    {
        tutorialTexts[3].gameObject.SetActive(false);
        tutorialTexts[4].gameObject.SetActive(true);

        if (GameManager.Instance.isCharacterActive)
        {
            activePhase = Phase.Phase6;
        }
    }

    void Phase6Behaviour()
    {
        tutorialTexts[4].gameObject.SetActive(false);
        tutorialTexts[5].gameObject.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            activePhase = Phase.Phase7;
        }
    }
    void Phase7Behaviour()
    {
        tutorialTexts[5].gameObject.SetActive(false);
        tutorialTexts[6].gameObject.SetActive(true);

        if (Input.GetMouseButtonDown(0))
        {
            activePhase = Phase.Phase8;
            GameManager.Instance.RestartLevel();
        }
    }

    void Phase8Behaviour()
    {
        tutorialTexts[6].gameObject.SetActive(false);
        tutorialTexts[7].gameObject.SetActive(true);
    }

    void Phase9Behaviour()
    {
        tutorialTexts[7].gameObject.SetActive(false);
        tutorialText.gameObject.SetActive(false);
        GameManager.Instance.isTutorialActive = false;
    }

    //IEnumerator PhaseEndRoutine()
    //{
    //    yield return new WaitForSeconds(5);
    //    activePhase = Phase.Phase2;
    //}

    //void SpawnEnemies()
    //{
    //    if (activePhase == Phase.Phase2)
    //    {
    //        Instantiate(enemy, new Vector3(12, 1, 0), enemy.transform.rotation);
    //        Instantiate(enemy, new Vector3(-12, 1, 0), enemy.transform.rotation);
    //        Instantiate(enemy, new Vector3(0, 1, 12), enemy.transform.rotation);
    //        Instantiate(enemy, new Vector3(0, 1, -12), enemy.transform.rotation);
    //    }

    //    if (activePhase == Phase.Phase3 || activePhase == Phase.Phase4)
    //    {
    //        for (int i = 0; i < 7; i++)
    //        {
    //            Instantiate(enemy, new Vector3(0, 1, 5 + i), enemy.transform.rotation);
    //        }
    //    }

    //    Enemy[] enemies = FindObjectsOfType<Enemy>();

    //    foreach (Enemy enemy in enemies)
    //    {
    //        enemy.speed = 0;
    //        enemy.enemyAnim.SetTrigger("gameOver"); // gameOver trigger sets enemy animation to Idle
    //    }
    //}
}
