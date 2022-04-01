using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    private bool isPlaying = false;
    private ActiveEnemies activeEnemies;
    private void Start()
    {
        isPlaying = false;
        activeEnemies = GetComponent<ActiveEnemies>();
    }

    private void Update()
    {
        if (isPlaying == false)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            activeEnemies.SetActiveGroup(0);
        }

        if (Input.touchCount > 0)
        {
            isPlaying = true;
        }
    }
}
