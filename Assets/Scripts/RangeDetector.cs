using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeDetector : MonoBehaviour
{

    [SerializeField] private Text statusText = null;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish Zone"){

            statusText.text = "Finish";
        }

        else if(other.tag == "Catch Zone"){
            statusText.text = "Catch";
        }

        statusText.text = other.name;
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Finish Zone" || other.tag == "Catch Zone"){
            statusText.text = "Rowing";
        }
    }

    
}
