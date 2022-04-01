using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    private NavMeshAgent agent;
    private bool isShootingMode;
    private Animator anim;

    public bool IsShootingMode
    { get => isShootingMode; }
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private int currentWaypoint;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        isShootingMode = true;
        SetDestination(0);
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null && agent.remainingDistance == 0)
        {
            isShootingMode = false;
            SetDestination(currentWaypoint);
            currentWaypoint++;
        }
        else
        {
            isShootingMode = true;
        }

        if (currentWaypoint > waypoints.Length)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (agent.remainingDistance > 0.2f)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void SetDestination(int waypoint)
    {
        if (currentWaypoint >= waypoints.Length)
        {
            return;
        }
        agent.destination = waypoints[waypoint].transform.position;
    }
}
