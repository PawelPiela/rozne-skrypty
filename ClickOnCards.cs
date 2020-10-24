using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    private int clickCounter = 0;
    public GameMenager gameMenager;

    private void Update() {  
        if (Input.GetMouseButtonDown(0)) ClickOnCard();
    }

     void ClickOnCard() {      
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        
        if (hit.transform != null && hit.transform.name == "CardsSet_BackSide(Clone)" && !gameMenager.isGameOver) {
            clickCounter++;          
            gameMenager.clickedCardsCounter = clickCounter;
            gameMenager.clickedCard = hit.transform.tag;
            Destroy(hit.transform.gameObject);
        } 
        
    }



}
