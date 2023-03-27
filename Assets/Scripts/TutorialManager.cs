using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public enum Phase { Phase1, Phase2, Phase3, Phase4 }
    public Phase activePhase;

    //private GameObject player;
    private GameManager gameManager;

    //public GameObject enemy;
    //public GameObject powerUp;

    public TextMeshProUGUI[] tutorialText;

    public bool isTutorialActive;

    private bool phaseSetUp;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("Player");
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutorialActive)
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
        }
    }

    void Phase1Behaviour()
    {
        tutorialText[0].gameObject.SetActive(true);
        //if (Vector3.Distance(player.transform.position, new Vector3(0, 1, 0)) > 0.1f)
        //{
        //    StartCoroutine(PhaseEndRoutine());
        //}

    }

    void Phase2Behaviour()
    {
        tutorialText[0].gameObject.SetActive(false);
        tutorialText[1].gameObject.SetActive(true);

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
        tutorialText[1].gameObject.SetActive(false);
        tutorialText[2].gameObject.SetActive(true);

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
        tutorialText[2].gameObject.SetActive(false);
        tutorialText[3].gameObject.SetActive(true);

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

    IEnumerator PhaseEndRoutine()
    {
        yield return new WaitForSeconds(5);
        activePhase = Phase.Phase2;
    }

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
