using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{
    enum BoatPowerStatus {Power, NoPower}

    public List<ChairMovement> chairMovementsList = null;
    private List<float> chairMovementCountTime = new List<float>();
    [SerializeField] private Image powerCoeffcient= null;
    [SerializeField] private Text powerLevelText = null;

    [SerializeField] private Text recordText = null;

    [SerializeField] private Text powerSpeed = null;

    [SerializeField] private WaveLine waveLine = null;



    private float limitedPowerTime = 1.0f;

    public int powerLevel = 0;

    public bool isCatch = false;

    private float powerCoeffcientTime;

    private BoatPowerStatus boatPowerStatus;

    private float totalSpeed;

    private float waterPower = 0.001f;

    public float record = 0.0f;

    public float maxRecord = 0.0f;

    private float bestSpeed = 0.0f;

    private float avgSpeed = 0.0f;

    private float totalTime = 0.0f;

    private bool isFinish = false;


    void Start(){

        for(int i = 0; i < chairMovementsList.Count; i++){
            chairMovementCountTime.Add(0.0f);
        }
    }

    void Update(){

        //after coroutine 3s, count time
        


        float speed = 0.0f;
        for(int j = 0 ; j < chairMovementsList.Count; j++){
            speed += chairMovementsList[j].speed;
            chairMovementsList[j].speed = 0.0f;
        }


        //when finished
        if(record <= 0.0f){

            FinishRowing();
            isFinish = true;

        }
        


        //cal speed and record time
        if(!isFinish){
        
            totalTime += Time.deltaTime;
            

            for(int i = 0 ; i < chairMovementsList.Count; i++){
                if(chairMovementsList[i].chairStatus == ChairMovement.ChairStatus.Rowing){
                    boatPowerStatus = BoatPowerStatus.Power;
                    //Do Power
                    totalSpeed += speed*0.01f;
                    if(speed > 0.1f){
                        totalSpeed *= (1.0f+powerLevel*0.01f);
                    }
                    break;
                }
                else{
                    boatPowerStatus = BoatPowerStatus.NoPower;
                }

            }
        }



        totalSpeed -= waterPower;
        
        if( totalSpeed < 0.0f){
            totalSpeed = -waterPower;
        }
        else if(totalSpeed > 1.0f){
            //if total speed is begger than 1.0f, it too much.......
            Debug.Log("Over Pace"+totalSpeed);
            totalSpeed = 1.0f;
        }        

        
        powerSpeed.text = string.Format("{0:F0} watt",totalSpeed*1000);
        waveLine.CalSpeed(totalSpeed);
        
        record -= totalSpeed;
        SetRecord();

        //best speed
        if(bestSpeed < totalSpeed*1000){
            bestSpeed = totalSpeed*1000;
        }

        //avg speed
        if(avgSpeed < 0.01f){
            avgSpeed = totalSpeed * 1000;
        }
        else if(!isFinish){
            avgSpeed += totalSpeed * 1000;
            avgSpeed /= 2;
        }


        //power coeffactor
        if(isCatch){
            powerCoeffcient.fillAmount -= 1.0f/(powerCoeffcientTime)* Time.deltaTime;

            if(powerCoeffcient.fillAmount <= 0.01f){
                isCatch = false;
                SetPowerLevel();
            }
            
        }
        else{
            //count time 값이 들어가야한다.
            powerCoeffcient.fillAmount = 1.0f;
        }
    }


    public void ObtainEachCountTime(){
        //first catch enter time
        powerCoeffcientTime = 0.0f;

        for(int i = 0; i < chairMovementsList.Count; i++){
            if(chairMovementsList[i].chairStatus == ChairMovement.ChairStatus.Catch){
                powerCoeffcientTime += chairMovementsList[i].countTime;
            }
            else{
                powerCoeffcientTime += 0.5f;
            }
            
        }
    }

    public void SetPowerLevel(){
        powerLevelText.text = string.Format("{0} x",powerLevel);
    }

    public void ResetPowerLevel(){
        
        powerLevel = 0;
    }

    private void SetRecord(){
        recordText.text = string.Format("{0:F0} m",record);
    }

    // public void ResetRecord(){
    //     record = 0.0f;
    //     SetRecord();
    // }

    public void ResetBoat(){

        waveLine.CalSpeed(0.0f);

        isFinish = false;

        boatPowerStatus = BoatPowerStatus.NoPower;

        waterPower = 0.001f;

        record = 0.0f;

        maxRecord = 0.0f;

        limitedPowerTime = 1.0f;

        powerLevel = 0;

        bestSpeed = 0.0f;

        avgSpeed = 0.0f;

        totalTime = 0.0f;

        SetRecord();



    }

    private void FinishRowing(){

            record = 0.0f;
            FinishRecordUI.instance.TurnOnFinishRecord((int)maxRecord,totalTime,bestSpeed,avgSpeed);
            powerLevel = 0;
            waterPower = 0.01f;
            totalSpeed = 0.02f;
    }

}
