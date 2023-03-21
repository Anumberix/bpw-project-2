using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public NavMeshAgent agentPlayer;
    public NavMeshAgent agentShip;
    public NavMeshSurface surfacePlayer;
    public NavMeshSurface surfaceShip;

    public Transform goal;

    //Vector3 target;

    public int[] bridgeStock;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.levelManager = this;
        agentPlayer.updateRotation = false;
        agentPlayer.updateUpAxis = false;
        agentShip.updateRotation = false;
        agentShip.updateUpAxis = false;
        surfacePlayer.UpdateNavMesh(surfacePlayer.navMeshData);
        surfaceShip.UpdateNavMesh(surfaceShip.navMeshData);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    agentPlayer.SetDestination(new Vector3(target.x, target.y, agentPlayer.gameObject.transform.position.z));
        //}
        //Debug.Log(agentPlayer.pathStatus);
    }

    public void UpdateNavMesh()
    {
        surfacePlayer.UpdateNavMesh(surfacePlayer.navMeshData);
        surfaceShip.UpdateNavMesh(surfaceShip.navMeshData);
    }
}
