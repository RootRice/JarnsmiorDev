using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SF_Click : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler {
 
	bool isChoice = false;
	public void setChoice(bool isChoice)
	{
		this.isChoice = isChoice;
	}
     public void OnPointerDown (PointerEventData eventData) {
		if(isChoice) {
			gameObject.ChoiceSelected();
		}
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
