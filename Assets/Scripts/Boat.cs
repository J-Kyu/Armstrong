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

    [SerializeField] private Text powerSpeed = null;

    [SerializeField] private WaveLine waveLine = null;


    private float limitedPowerTime = 1.0f;

    public int powerLevel = 0;

    public bool isCatch = false;

    private float powerCoeffcientTime;

    private BoatPowerStatus boatPowerStatus;

    private float powerTime;


    void Start(){

        boatPowerStatus = BoatPowerStatus.NoPower;

        powerCoeffcientTime = 0.0f;
        powerTime = 0.0f;

        for(int i = 0; i < chairMovementsList.Count; i++){
            chairMovementCountTime.Add(0.0f);
        }
    }

    void Update(){

        powerTime += Time.deltaTime;

        float speed = 0.0f;
        for(int j = 0 ; j < chairMovementsList.Count; j++){
            speed += chairMovementsList[j].speed;
        }


        for(int i = 0 ; i < chairMovementsList.Count; i++){
            if(chairMovementsList[i].chairStatus == ChairMovement.ChairStatus.Rowing){
                boatPowerStatus = BoatPowerStatus.Power;
                //Do Power
                powerTime  = 0.0f;
                break;
            }
            else{
                boatPowerStatus = BoatPowerStatus.NoPower;
            }

        }



        if( powerTime > Mathf.PI/2){
            powerSpeed.text = string.Format("{0:F0} watt",0);    
        }        
        else{
            powerSpeed.text = string.Format("{0:F0} watt",Mathf.Abs(Mathf.Cos(powerTime))*speed*10);
        }


        waveLine.CalSpeed(powerTime,powerLevel,speed);

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

   
}
