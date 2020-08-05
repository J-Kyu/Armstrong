using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeDetector : MonoBehaviour
{

    [SerializeField] private Text statusText = null;

    [SerializeField] private ChairMovement chairMovement = null;

    [SerializeField] private Transform bladeTrans = null;

    private const float turnSpeed = 45.0f;

    void Update(){



        switch(chairMovement.chairStatus){
            case ChairMovement.ChairStatus.Catch:{
                TurnVertical(75);
                break;
            }

            case ChairMovement.ChairStatus.Rowing:{

                break;
            }
            case ChairMovement.ChairStatus.Finish:{
                TurnHorizontal(1);
                break;

            }
            case ChairMovement.ChairStatus.Recovery:{
                TurnHorizontal(1);

                break;
            }


            default: {

                break;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish Zone"){

            statusText.text = "Finish";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Finish;
            // bladeTrans.rotation.x
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


    private void TurnVertical(float angle){

        if(bladeTrans.localEulerAngles.x < angle){

               bladeTrans.Rotate(new Vector3(1,0,0) * turnSpeed * Time.deltaTime);
        }
        else{
            bladeTrans.localEulerAngles = new Vector3(angle,0,0);
        }

     
    }

    private void TurnHorizontal(float angle){

        if(bladeTrans.localEulerAngles.x > angle){
            bladeTrans.Rotate(new Vector3(-1,0,0) * turnSpeed * Time.deltaTime);
        }
        else{
            bladeTrans.localEulerAngles = new Vector3(angle,0,0);
        }

        
    }
    
}
