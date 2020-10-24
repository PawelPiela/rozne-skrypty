using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SpawnCards : MonoBehaviour {

    int halfOfSpawns;
    public GameObject[] cardSpawnPos;
    public GameObject[] playingCards;
    public GameObject cardBackside;

    int[] firstSetOfSpawns;
    int[] secondSetOfSpawns;
    int[] selectedCards;

    public void RoundStart(int hidingCardsDelay) {
        halfOfSpawns = cardSpawnPos.Length / 2;
        firstSetOfSpawns = new int[halfOfSpawns];
        secondSetOfSpawns = new int[halfOfSpawns];
        selectedCards = new int[halfOfSpawns];

        for (int i = 0; i < halfOfSpawns; i++) {
            firstSetOfSpawns[i] = -1;
            secondSetOfSpawns[i] = -1;
        }

        FirstSetOfCardPositions();
        SecondSetOfCardPositions();
        CardSelection();
        Spawn();
        Invoke("SpawnBackside", hidingCardsDelay);     
        
    }

    void FirstSetOfCardPositions() {
        for (int i = 0; i < halfOfSpawns; i++) {
            firstSetOfSpawns[i] = SpawnPos1(0, cardSpawnPos.Length, firstSetOfSpawns);
        }
    }
    void SecondSetOfCardPositions() {

        for (int i = 0; i < halfOfSpawns; i++) {
            secondSetOfSpawns[i] = SpawnPos2(0, cardSpawnPos.Length, firstSetOfSpawns, secondSetOfSpawns);
        }
    }

    int SpawnPos1(int min, int max, int[] array) {
        int element;
        do {
            element = UnityEngine.Random.Range(min, max);
        } while (Array.IndexOf(array, element) != -1);
        return element;
    }
    int SpawnPos2(int min, int max, int[] firstArray, int[] secondArray) {
        int element;
        bool existsInFirst;
        bool existsInSecond;
        do {
            element = UnityEngine.Random.Range(min, max);
            existsInFirst = Array.IndexOf(firstArray, element) != -1;
            existsInSecond = Array.IndexOf(secondArray, element) != -1;
        } while (existsInFirst || existsInSecond);
        return element;
    }
    void CardSelection() {
        for (int i = 0; i < halfOfSpawns; i++) {
            selectedCards[i] = SpawnPos1(0, playingCards.Length, selectedCards);
            //Debug.Log(selectedCards[i]);
        }
    }
    void Spawn() {
        for (int i = 0; i < halfOfSpawns; i++) {
            GameObject card = Instantiate(playingCards[selectedCards[i]]);
            GameObject cardDuplicate = Instantiate(playingCards[selectedCards[i]]);
            Vector2 cardPos = new Vector2();

            cardPos = cardSpawnPos[firstSetOfSpawns[i]].transform.position;
            card.transform.position = new Vector2(cardPos.x, cardPos.y);
            
            cardPos = cardSpawnPos[secondSetOfSpawns[i]].transform.position;
            cardDuplicate.transform.position = new Vector2(cardPos.x, cardPos.y);

        }
    }
    void SpawnBackside() {
        int counter = halfOfSpawns;

        for (int i = 0; i < counter; i++) {
            
            GameObject backside = Instantiate(cardBackside); 
            Vector2 cardPos = new Vector2();
            cardPos = cardSpawnPos[firstSetOfSpawns[i]].transform.position;
            backside.transform.position = new Vector2(cardPos.x, cardPos.y);
            backside.tag = ("Card_" + i);
        }
        for (int i = 0; i < counter; i++) {

            GameObject backside = Instantiate(cardBackside);
            Vector2 cardPos = new Vector2();
            cardPos = cardSpawnPos[secondSetOfSpawns[i]].transform.position;
            backside.transform.position = new Vector2(cardPos.x, cardPos.y);
            backside.tag = ("Card_" + i);
        }
    }
}