using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float waitToLoad = 4f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
        Debug.Log("numberofattackers = " + numberOfAttackers);
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        Debug.Log("numberofattackers = " + numberOfAttackers);
        CheckWinCondition();
    }

    public void CheckWinCondition()
    {
        if (numberOfAttackers <= 0 && levelTimerFinished && !loseLabel.activeSelf)
        {
            StartCoroutine(HandleWinCondition());
            Debug.Log("End Level Now!");
        };
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<LevelLoad>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
        CheckWinCondition();
    }

    private void StopSpawners()
    {
        AttackSpawner[] spawnerArray = FindObjectsOfType<AttackSpawner>();
        foreach (AttackSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
