using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private SelectBlock spawner;
    [SerializeField] private GameObject StartUI;
    [SerializeField] private GameObject ResetUI;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private InteractableUnityEventWrapper buttonController;
    [SerializeField] private LeverScript[] leverControllers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMenu()
    {
        StartUI.SetActive(true);
        ResetUI.SetActive(false);
        MenuUI.SetActive(false);
        foreach (LeverScript leverController in leverControllers)
        {
            leverController.enabled = true;
        }
        foreach (RandomizedBlocks block in spawner.blocks)
        {
            block.enabled = true;
            block.ResetBlock();
        }
        buttonController.enabled = true;
    }

    public void SelectEasy()
    {
        StartUI.SetActive(false);
        spawner.enabled = true;
        spawner.maxBlocks = 3;
        spawner.SpawnWaitTime = 3;
        spawner.holdWaitTime = 3;
    }

    public void SelectMedium()
    {
        StartUI.SetActive(false);
        spawner.enabled = true;
        spawner.maxBlocks = 5;
        spawner.SpawnWaitTime = 2;
        spawner.holdWaitTime = 3;
    }

    public void SelectHard()
    {
        StartUI.SetActive(false);
        spawner.enabled = true;
        spawner.maxBlocks = 8;
        spawner.SpawnWaitTime = 2;
        spawner.holdWaitTime = 2;
    }

    public void SelectImpossible()
    {
        StartUI.SetActive(false);
        spawner.enabled = true;
        spawner.maxBlocks = 8;
        spawner.SpawnWaitTime = 1;
        spawner.holdWaitTime = 1;
    }
}
