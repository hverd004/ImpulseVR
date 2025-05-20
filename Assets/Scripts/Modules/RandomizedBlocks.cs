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
    [SerializeField] private AudioClip correctActionAudio;
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

    public void SetUpBlock(Sprite cSprite, string command, int waittime)
    {
        if (!active)
        {
            blockImg.enabled = true;
            blockImg.sprite = cSprite;
            cCommand = command;
            StartCoroutine(this.CountDown(waittime));
            active = true;
        }
    }
    private IEnumerator CountDown(int waittime)
    {
        blockRenderer.material.color = Color.green;
        yield return new WaitForSeconds(waittime);
        blockRenderer.material.color = Color.yellow;
        yield return new WaitForSeconds(waittime);
        blockRenderer.material.color = Color.red;
        yield return new WaitForSeconds(waittime);
        fail = true;
    }

    public void ResetBlock()
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
        PlayerInputs.OnJoystickDown += HandleJoystickDown;
        PlayerInputs.OnJoystickUp += HandleJoystickUp;
        WheelScript.OnGreen += HandleOnGreen;
        WheelScript.OnRed += HandleOnRed;
        WheelScript.OnYellow += HandleOnYellow;
        WheelScript.OnBlue += HandleOnBlue;
    }

    private void OnDisable()
    {
        PlayerInputs.OnXPressed -= HandleXPressed;
        PlayerInputs.OnYPressed -= HandleYPressed;
        LeverScript.LeverDown -= HandleLevelDown;
        LeverScript.LeverUp -= HandleLevelUp;
        PlayerInputs.OnJoystickDown -= HandleJoystickDown;
        PlayerInputs.OnJoystickUp -= HandleJoystickUp;
        WheelScript.OnGreen -= HandleOnGreen;
        WheelScript.OnRed -= HandleOnRed;
        WheelScript.OnYellow -= HandleOnYellow;
        WheelScript.OnBlue -= HandleOnBlue;
    }

    private void HandleXPressed()
    {
        if (!active) return;

        if (cCommand == "PressX")
        {
            Debug.Log($"{gameObject.name} received correct X input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }
    private void HandleYPressed()
    {
        if (!active) return;

        if (cCommand == "PressY")
        {
            Debug.Log($"{gameObject.name} received correct Y input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }

    private void HandleLevelUp()
    {
        if (!active) return;

        if (cCommand == "LeverUp")
        {
            Debug.Log($"{gameObject.name} received correct Lever input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }

    private void HandleLevelDown()
    {
        if (!active) return;

        if (cCommand == "LeverDown")
        {
            Debug.Log($"{gameObject.name} received correct Lever input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }

    public void HandleHandDown()
    {
        if (!active) return;

        if(cCommand == "HandDown")
        {
            Debug.Log($"{gameObject.name} received correct Hand input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }

    public void HandleJoystickDown()
    {
        if (!active) return;

        if (cCommand == "JoystickDown")
        {
            Debug.Log($"{gameObject.name} received correct Joystick Down input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }

    public void HandleJoystickUp()
    {
        if (!active) return;

        if (cCommand == "JoystickUp")
        {
            Debug.Log($"{gameObject.name} received correct Joystick Up input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }

    public void HandleOnGreen()
    {
        if (!active) return;

        if (cCommand == "OnGreen")
        {
            Debug.Log($"{gameObject.name} received correct Color Green input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }

    public void HandleOnBlue()
    {
        if (!active) return;

        if (cCommand == "OnBlue")
        {
            Debug.Log($"{gameObject.name} received correct Color Blue input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }
    public void HandleOnYellow()
    {
        if (!active) return;

        if (cCommand == "OnYellow")
        {
            Debug.Log($"{gameObject.name} received correct Color Yellow input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }
    public void HandleOnRed()
    {
        if (!active) return;

        if (cCommand == "OnRed")
        {
            Debug.Log($"{gameObject.name} received correct Color Red input!");
            GameTracker.cScore += 1;
            GetComponent<AudioSource>().clip = correctActionAudio;
            GetComponent<AudioSource>().Play();
            ResetBlock();
        }
    }
}
