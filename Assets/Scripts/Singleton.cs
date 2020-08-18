using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Singleton : MonoBehaviour
{
    [SerializeField] LogContent logContent = null; 
    [SerializeField] ArmstrongManager armstrongManager = null; 

    [SerializeField]   FinishRecordUI finishRecordUI = null; 


    void Awake(){
        LogContent.instance = logContent;
        ArmstrongManager.instance = armstrongManager;
        FinishRecordUI.instance = finishRecordUI;
    }



}
