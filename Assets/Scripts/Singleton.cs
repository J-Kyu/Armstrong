using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Singleton : MonoBehaviour
{
    [SerializeField] LogContent logContent = null; 


    void Awake(){
        LogContent.instance = logContent;
    }



}
