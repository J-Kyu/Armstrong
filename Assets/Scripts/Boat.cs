using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boat : MonoBehaviour
{

    [SerializeField] private List<ChairMovement> chairMovementsList = null;

    private List<bool> chairMovementCatchList = new List<bool>();

    [SerializeField] private Image powerCoeffcient= null;


    private float limitedPowerTime = 1.0f;

    private int powerLevel = 0;

    private bool isCatch = false;

    void Start(){

        for(int i = 0; i < chairMovementsList.Count; i++){
            chairMovementCatchList.Add(false);
        }
    }

    void Update(){


        if(isCatch){
            //run PowerCoefficient
            powerCoeffcient.fillAmount -= Time.deltaTime;
            for( int i = 0; i < chairMovementsList.Count; i++){
                if(chairMovementsList[i].chairStatus == ChairMovement.ChairStatus.Catch && chairMovementCatchList[i] != true){
                    chairMovementCatchList[i] = true;
                    powerLevel++;        
                }
            }


        }
        else{
            CheckCatch();
        }
        
    }


    private void CheckCatch(){

        for( int i = 0; i < chairMovementsList.Count; i++){
            if(chairMovementsList[i].chairStatus == ChairMovement.ChairStatus.Catch){
                powerLevel++;
                chairMovementCatchList[i] = true;
                isCatch = true;

                return;
            }
        }
        isCatch = false;
    }

}
