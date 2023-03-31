using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public enum Phase { Phase1, Phase2, Phase3, Phase4, Phase5, Phase6, Phase7, Phase8, Phase9 }
    public Phase activePhase;
    public BridgeSpot[] bridgeSpots;

    public TextMeshProUGUI[] tutorialTexts;
    public GameObject tutorialText;

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

    }

    void Phase2Behaviour()
    {
        tutorialTexts[0].gameObject.SetActive(false);
        tutorialTexts[1].gameObject.SetActive(true);

        if (bridgeSpots[0].IsSelected)
        {
            activePhase = Phase.Phase3;
        }        
    }

    void Phase3Behaviour()
    {
        tutorialTexts[1].gameObject.SetActive(false);
        tutorialTexts[2].gameObject.SetActive(true);

        if (bridgeSpots[0].ActiveBridge == bridgeSpots[0].bridgeTypes[1])
        {
            activePhase = Phase.Phase4;
        }
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
}
