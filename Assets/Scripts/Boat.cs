using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{

    [SerializeField] private List<ChairMovement> chairMovementsList = null;

    private List<float> chairMovementCountTime = new List<float>();

    [SerializeField] private Image powerCoeffcient= null;

    [SerializeField] private Text poewrLevel = null;


    private float limitedPowerTime = 1.0f;

    private int powerLevel = 0;

    private bool isCatch = false;

    private float powerCoeffcientTime;

    private bool isSummed = false;



    void Start(){

        powerCoeffcientTime = 0.0f;

        for(int i = 0; i < chairMovementsList.Count; i++){
            chairMovementCountTime.Add(0.0f);
        }
    }

    void Update(){


        if(isCatch){
            //start power coefficient
            SumCountTime();
            powerCoeffcient.fillAmount -= 1.0f/(powerCoeffcientTime)* Time.deltaTime;

            if(powerCoeffcient.fillAmount <= 0.01f){
                isCatch = false;
            }
            
        }
        else{
            //count time 값이 들어가야한다.
            powerCoeffcient.fillAmount = 1.0f;
            isSummed =false;
            powerLevel = 0;
            
        }

    }

    public void SetCatch(bool isCatch){
        this.isCatch = isCatch;
    }

    private void SumCountTime(){
        if(isSummed){
            return;
        }

        for(int i = 0; i< chairMovementsList.Count; i++){
                powerCoeffcientTime += chairMovementsList[i].countTime;
        }

        isSummed = true;
    }

    public void IncreasePowerLevel(){
        powerLevel++;
        poewrLevel.text = string.Format("{0}x",powerLevel);
    }
}
