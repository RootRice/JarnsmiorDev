using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SF_Click : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
 
	bool isChoice = false;

    private GameManager mGameManager;

	private int msgID;

	void Start () {
        mGameManager = (GameManager)GameObject.FindGameObjectWithTag("SF_GameManager").GetComponent(typeof(GameManager));
	}
	

	public void setChoice(bool isChoice)
	{
		this.isChoice = isChoice;
	}
     public void OnPointerDown (PointerEventData eventData) {
         // Do action
		print("I'm attached to " + gameObject);
		if(isChoice) {
			mGameManager.OptionSelected(msgID);
        }
     }

	 public void SetID(int msgID) {
		 this.msgID = msgID;
	 }
 
     public void OnPointerUp (PointerEventData eventData) {
		if(isChoice) {
			
		}
     }
 
     public void OnPointerEnter(PointerEventData eventData)
     {
		if(isChoice) {
			
		}
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
		if(isChoice) {
			
		}
     }

 }
