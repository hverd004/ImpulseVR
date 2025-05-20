using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBlock : MonoBehaviour
{
    [SerializeField] private Sprite[] commands;
    public RandomizedBlocks[] blocks;
    [SerializeField] private string[] commandStrings;
    [SerializeField] private AudioClip blockSpawnSound;
    public int maxBlocks = 3;
    public int SpawnWaitTime  = 3;
    public int holdWaitTime = 3;
    private int cBlocks = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cBlocks < maxBlocks)
        {
            StartCoroutine(SelectRandomBlock());
        }
    }

    private IEnumerator SelectRandomBlock()
    {
        Debug.Log("Selecting Block");
        cBlocks += 1;
        int r;
        int b;
        r = Random.Range(0, commands.Length);
        b = Random.Range(0, blocks.Length);
        blocks[b].SetUpBlock(commands[r], commandStrings[r], holdWaitTime);
        blocks[b].gameObject.GetComponent<AudioSource>().clip = blockSpawnSound;
        blocks[b].gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(SpawnWaitTime);
        cBlocks -= 1;
    }
}
