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

    public bool isCatch = false;

    private float powerCoeffcientTime;



    void Start(){

        powerCoeffcientTime = 0.0f;

        for(int i = 0; i < chairMovementsList.Count; i++){
            chairMovementCountTime.Add(0.0f);
        }
    }

    void Update(){

        if(isCatch){
            powerCoeffcient.fillAmount -= 1.0f/(powerCoeffcientTime)* Time.deltaTime;

            if(powerCoeffcient.fillAmount <= 0.01f){
                isCatch = false;
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

   
}
