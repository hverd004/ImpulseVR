using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class RandomizedBlocks : MonoBehaviour
{
    [SerializeField] private Image blockImg;
    [SerializeField] private string cCommand;
    [SerializeField] private MeshRenderer blockRenderer;
    [SerializeField] private int speed = 8;
    private bool active;
    private bool fail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fail)
        {
            this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, new Vector3(7.5f, this.transform.localScale.y, this.transform.localScale.z), speed * Time.deltaTime);
        }
    }

    public void SetUpBlock(Sprite cSprite, string command)
    {
        if (!active)
        {
            blockImg.enabled = true;
            blockImg.sprite = cSprite;
            cCommand = command;
            StartCoroutine(this.CountDown());
            active = true;
        }
    }
    private IEnumerator CountDown()
    {
        blockRenderer.material.color = Color.green;
        yield return new WaitForSeconds(3);
        blockRenderer.material.color = Color.yellow;
        yield return new WaitForSeconds(3);
        blockRenderer.material.color = Color.red;
        yield return new WaitForSeconds(3);
        fail = true;
    }

    private void ResetBlock()
    {
        StopAllCoroutines();
        active = false;
        fail = false;
        blockRenderer.material.color = new Color(155/255f, 1, 1);
        this.transform.localScale = new Vector3(.75f, .75f, .75f);
        blockImg.enabled = false;
        cCommand = "";
    }

    //check inputs
    private void OnEnable()
    {
        PlayerInputs.OnXPressed += HandleXPressed;
        PlayerInputs.OnYPressed += HandleYPressed;
        LeverScript.LeverDown += HandleLevelDown;
        LeverScript.LeverUp += HandleLevelUp;
    }

    private void OnDisable()
    {
        PlayerInputs.OnXPressed -= HandleXPressed;
        PlayerInputs.OnYPressed -= HandleYPressed;
        LeverScript.LeverDown -= HandleLevelDown;
        LeverScript.LeverUp -= HandleLevelUp;
    }

    private void HandleXPressed()
    {
        if (!active) return;

        if (cCommand == "PressX")
        {
            Debug.Log($"{gameObject.name} received correct X input!");
            ResetBlock();
        }
    }
    private void HandleYPressed()
    {
        if (!active) return;

        if (cCommand == "PressY")
        {
            Debug.Log($"{gameObject.name} received correct Y input!");
            ResetBlock();
        }
    }

    private void HandleLevelUp()
    {
        if (!active) return;

        if (cCommand == "LeverUp")
        {
            Debug.Log($"{gameObject.name} received correct Lever input!");
            ResetBlock();
        }
    }

    private void HandleLevelDown()
    {
        if (!active) return;

        if (cCommand == "LeverDown")
        {
            Debug.Log($"{gameObject.name} received correct Lever input!");
            ResetBlock();
        }
    }
}
