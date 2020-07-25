using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite normal;
    public Sprite over;

    private Button playBT;
    private Image spriteRender;
    private Vector3 initPos;

    private void Awake(){
        playBT = this.GetComponent<Button>();
        spriteRender = this.GetComponent<Image>(); 
        initPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        playBT.onClick.AddListener(TaskOnClick);
    }

    public void OnPointerEnter(PointerEventData eventData){
        spriteRender.sprite = over;
        this.transform.position = new Vector3(initPos.x, initPos.y - 118, initPos.z);
    }

    public void OnPointerExit(PointerEventData eventData){
        spriteRender.sprite = normal;
        this.transform.position = initPos;
    }

    private void TaskOnClick(){
        SceneManager.LoadScene("Level1");
        Debug.Log("You have clicked the button!");
    }
}
