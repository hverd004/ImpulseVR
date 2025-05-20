using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    public static event System.Action OnRed;
    public static event System.Action OnGreen;
    public static event System.Action OnBlue;
    public static event System.Action OnYellow;

    [SerializeField] private string Color;
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
        if(other.gameObject.CompareTag("Crank"))
        {
            if (Color.Equals("Green"))
            {
                //Debug.Log("Green");
                OnGreen?.Invoke();
            }
            if (Color.Equals("Red"))
            {
                //Debug.Log("Red");
                OnRed?.Invoke();
            }
            if (Color.Equals("Blue"))
            {
                //Debug.Log("Blue");
                OnBlue?.Invoke();
            }
            if (Color.Equals("Yellow"))
            {
                //Debug.Log("Yellow");
                OnYellow?.Invoke();
            }
        }
    }
}
