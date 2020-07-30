using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogContent : MonoBehaviour
{
    
    public static LogContent instance;

    [SerializeField] private Text logText = null;


    private List<string> logDataList = new List<string>();
    public void SaveLog(string from ,string data){
    
        string log = string.Format("{0} : {1} \t {2}",System.DateTime.Now,from,data);
        AddLog(log);
        
    }


    private void AddLog(string log){

        if(logText == null){
            Debug.Log("WOW");
            return;
        }
        logText.text += "\n"+log;
    }

    public void ResetLog(){
        logText.text = "";
    }
}
