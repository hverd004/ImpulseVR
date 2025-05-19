using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private SelectBlock spawner;
    [SerializeField] private GameObject ResetUi;
    [SerializeField] private GameObject MenuUi;
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


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit");
        if (other.gameObject.CompareTag("Module"))
        {
            Debug.Log("recognized hit");
            spawner.enabled = false;
            ResetUi.SetActive(true);
            MenuUi.SetActive(true);
            buttonController.enabled = false;
            foreach (LeverScript leverController in leverControllers)
            {
                leverController.enabled = false;
            }
            foreach (RandomizedBlocks block in spawner.blocks)
            {
                block.enabled = false;
            }
        }
    }

    public void ResetGame()
    {
        spawner.enabled = true;
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
        ResetUi.SetActive(false);
        MenuUi.SetActive(false);
    }
}
