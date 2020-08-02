using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeDetector : MonoBehaviour
{

    [SerializeField] private Text statusText = null;

    [SerializeField] private ChairMovement chairMovement = null;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish Zone"){

            statusText.text = "Finish";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Finish;
        }

        else if(other.tag == "Catch Zone"){
            statusText.text = "Catch";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Catch;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Catch Zone" ){
            statusText.text = "Rowing";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Rowing;
        }
        else if(other.tag == "Finish Zone"){
            statusText.text = "Recovery";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Recovery;
        }
    
    }

    
}
