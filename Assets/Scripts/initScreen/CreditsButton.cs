using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{

    public string creditsStatus = "closed";
    public GameObject credits;
    public Sprite openPopup;
    public Sprite closePopup;
    private Image spriteRender;
    private Button playBT;

    void Start(){
        creditsStatus = "closed";
        playBT = this.GetComponent<Button>();
        spriteRender = this.GetComponent<Image>();
        playBT.onClick.AddListener(clickCredits);
    }


    private void clickCredits(){
        if (creditsStatus == "closed"){
            creditsStatus = "opened";
            spriteRender.sprite = closePopup;
            credits.active = true;
        }else{
            creditsStatus = "closed";
            spriteRender.sprite = openPopup;
            credits.active = false;
        }
    }
}
