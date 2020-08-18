using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishRecordUI : MonoBehaviour
{
    public static FinishRecordUI instance;
    [SerializeField] private Text titleText = null;

    [SerializeField] private Text timeText = null;

    [SerializeField] private Text bestSpeedText = null;

    [SerializeField] private Text avgPowerText = null;




    public void TurnOnFinishRecord(int length, float time, float bestSpeed, float avgPower){
        this.gameObject.SetActive(true);
        titleText.text = string.Format("{0} Record",length);
        timeText.text = string.Format("{0:F1} sec",time);
        bestSpeedText.text = string.Format("{0:F0} watt",bestSpeed);
        avgPowerText.text = string.Format("{0:F0} watt",avgPower);


    }


    public void ReturnToIntro(){
        TurnOnFinishRecord(0,0.0f,0.0f,0.0f);
        this.gameObject.SetActive(false);
        ArmstrongManager.instance.ReturnToIntro();
    }




}
