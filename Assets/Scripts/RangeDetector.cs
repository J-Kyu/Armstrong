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
    
    [SerializeField] private Text catchToFinishText = null;
    [SerializeField] private Text deltaText = null;
    [SerializeField] private Text speedText = null;

    private const float catchTurnSpeed = 120.0f;
    private const float finishTurnSpeed = 150.0f;

    private const float bladeMaxAngle = 75.0f;
    private const float bladeMinAngle = 0.0f;

    private float catchToFinish = 0.0f;
    private float pastPos;

    void Update(){


        catchToFinishText.text = string.Format("Time: {0:F3}",catchToFinish); 



        switch(chairMovement.chairStatus){
            case ChairMovement.ChairStatus.Catch:{
                TurnVertical();
                //reset count
                break;
            }

            case ChairMovement.ChairStatus.Rowing:{
                catchToFinish += Time.deltaTime*10.0f;

                CalculateSpeed();
                //speed
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

            //end count
            chairMovement.countTime = catchToFinish;
            CalculateSpeed();
            catchToFinish = 0.0f;
            
            chairMovement.boat.ResetPowerLevel();
            chairMovement.boat.SetPowerLevel();

        }

        else if(other.tag == "Catch Zone"){
            statusText.text = "Catch";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Catch;
            chairMovement.boat.isCatch = true;
            //set rest of player count time ( if not ready, set as default 1s)
            //this is whole function in boat

            chairMovement.boat.ObtainEachCountTime();

            chairMovement.boat.powerLevel++;
            Debug.Log(chairMovement.boat.powerLevel);
            chairMovement.boat.SetPowerLevel();

            //reset all count time
            chairMovement.countTime = 0.0f;
            
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Catch Zone" ){
            statusText.text = "Rowing";
            chairMovement.chairStatus = ChairMovement.ChairStatus.Rowing;
            chairMovement.boat.isCatch = false;

            pastPos = bladeTrans.position.y;
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

    private void CalculateSpeed(){
        
        float delta =  bladeTrans.position.y - pastPos ;



        pastPos = bladeTrans.position.y;
        delta *= 10.0f;

        deltaText.text = string.Format("Delta: {0:F3}",delta);

    

        if(catchToFinish < 1.0f){
            catchToFinish = 1.0f;
        }

        chairMovement.speed = (delta/catchToFinish)*(bladeTrans.localEulerAngles.x*100.0f)/7500.0f;
        speedText.text = string.Format("Speed: {0:F3}",chairMovement.speed);  
    }
    
}
