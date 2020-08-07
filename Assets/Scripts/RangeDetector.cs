using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangeDetector : MonoBehaviour
{

    [SerializeField] private Text statusText = null;

    [SerializeField] private ChairMovement chairMovement = null;

    [SerializeField] private Transform bladeTrans = null;

    [SerializeField] private Text turnPercetageText = null;

    private const float catchTurnSpeed = 90.0f;
    private const float finishTurnSpeed = 150.0f;

    private const float bladeMaxAngle = 75.0f;
    private const float bladeMinAngle = 0.0f;

    private float catchToFinish = 0.0f;

    void Update(){



        switch(chairMovement.chairStatus){
            case ChairMovement.ChairStatus.Catch:{
                TurnVertical();
                //reset count
                break;
            }

            case ChairMovement.ChairStatus.Rowing:{
                catchToFinish += Time.deltaTime;
                break;
            }
            case ChairMovement.ChairStatus.Finish:{
                TurnHorizontal();
                break;

            }
            case ChairMovement.ChairStatus.Recovery:{
                TurnHorizontal();

                break;
            }


            default: {

                break;
            }

        }
        if(bladeTrans.localEulerAngles.x > bladeMaxAngle){
            turnPercetageText.text  = string.Format("Turn: {0:F0}%",0);
        }
        else{
            turnPercetageText.text  = string.Format("Turn: {0:F0}%",((bladeTrans.localEulerAngles.x)*100.0f/75.0f));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Finish Zone"){

            statusText.text = "Finish";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Finish;
            chairMovement.boat.SetCatch(false);
            //end count
            chairMovement.countTime = catchToFinish;
            catchToFinish = 0.0f;
        }

        else if(other.tag == "Catch Zone"){
            statusText.text = "Catch";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Catch;
            chairMovement.boat.SetCatch(true);
            chairMovement.boat.IncreasePowerLevel();
            
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Catch Zone" ){
            statusText.text = "Rowing";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Rowing;
            //start count
            chairMovement.countTime = 0;
        }
        else if(other.tag == "Finish Zone"){
            statusText.text = "Recovery";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Recovery;
        }
    
    }


    private void TurnVertical(){

        if(bladeTrans.localEulerAngles.x < bladeMaxAngle || bladeTrans.localEulerAngles.x > 350.0f ){

               bladeTrans.Rotate(new Vector3(1,0,0) * catchTurnSpeed * Time.deltaTime);
        }
        else{
            bladeTrans.localEulerAngles = new Vector3(bladeMaxAngle,0,0);
        }

     
    }

    private void TurnHorizontal(){


        if(bladeTrans.localEulerAngles.x > 75){
            bladeTrans.localEulerAngles = new Vector3(bladeMinAngle,0,0);
        }
        else{
            bladeTrans.Rotate(new Vector3(-1,0,0) * finishTurnSpeed * Time.deltaTime);
        }

        
    }
    
}
