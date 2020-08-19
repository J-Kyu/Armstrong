using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoatThumbnail : MonoBehaviour
{
    [SerializeField] private Image thumbnailImage = null;
    [SerializeField] private Text thumbnailText = null;

    [SerializeField] private BoatType boatType;

    void Update(){

        this.gameObject.transform.rotation = Quaternion.Euler(0, 0, -this.gameObject.transform.parent.transform.rotation.z);
    }

    public void SetAlpha(float ratio){


        thumbnailImage.color = new Color (thumbnailImage.color.r,thumbnailImage.color.g,thumbnailImage.color.b, ratio);
        thumbnailText.color = new Color (thumbnailText.color.r,thumbnailText.color.g,thumbnailText.color.b, ratio);
    }

    public void SetBoat(){
        switch(boatType){
            case BoatType.x2:{
                ArmstrongManager.instance.boatType = BoatType.x2;
                break;
            }
            case BoatType.x4:{
                ArmstrongManager.instance.boatType = BoatType.x4;
                break;
            }
            default:{   
                ArmstrongManager.instance.boatType = BoatType.x2;
                break;
            }
        }

    }
}
