using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    //false = -, true = +
    [SerializeField] private bool directionSet = false;

    public static event System.Action LeverDown;
    public static event System.Action LeverUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Lever"))
        {
            if(directionSet)
            {
                LeverUp.Invoke();
            }
            else
            {
                LeverDown.Invoke();
            }
        }
    }
}
