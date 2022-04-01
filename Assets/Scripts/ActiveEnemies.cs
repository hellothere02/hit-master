using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyGroup
{
    public GameObject[] enemiesInGroup;
}
public class ActiveEnemies : MonoBehaviour
{
    [SerializeField] private List<EnemyGroup> enemies;
    [SerializeField] private int indexGroup = 1;
    private CharacterController characterController;


    private void Start()
    {
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
    }
    public void SetActiveGroup(int ind)
    {
        foreach (GameObject item in enemies[ind].enemiesInGroup)
        {
            item.SetActive(true);
        }
    }

    private void Update()
    {
        if (characterController.IsShootingMode == false)
        {
            if (indexGroup >= enemies.Count)
            {
                return;
            }
            StartCoroutine("StartSetActiveGroup");
        }
    }

    IEnumerator StartSetActiveGroup()
    {
        yield return new WaitForSeconds(1);
        SetActiveGroup(indexGroup);
        indexGroup++;
    }
}
