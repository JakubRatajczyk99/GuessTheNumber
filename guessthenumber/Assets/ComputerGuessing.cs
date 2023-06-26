using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ComputerGuessing : MonoBehaviour
{
    public Text infoText; // Referencje
    public Button startButton;
    public GameObject startButtonObject;
    public Button correctButton;
   



    int minRange; // Minimalny zakres zgadywania
    int maxRange; // Maksymalny zakres zgadywania
    int guessedNumber; // Zgadywana liczba





    public void StartGuessing()
    {


        startButton.image.enabled = false; // Wy³¹cz renderowanie obrazka przycisku
        startButton.interactable = false; // Wy³¹cz interakcjê z przyciskiem
        startButtonObject.SetActive(false); // Wy³¹cz obiekt przycisku startowego

        Debug.Log("StartGuessing() called");



        // Inicjalizacja pocz¹tkowych wartoœci zakresu i liczby
        minRange = 0;
        maxRange = 100;
        guessedNumber = Random.Range(minRange, maxRange + 1);
        


        // W³¹czenie interakcji z przyciskami "Wiêkszy" i "Mniejszy" 
        Button greaterButton = GameObject.Find("Wiêkszy").GetComponent<Button>();
        greaterButton.interactable = true;

        Button smallerButton = GameObject.Find("Mniejszy").GetComponent<Button>();
        smallerButton.interactable = true;

        Button correctButton = GameObject.Find("Tak").GetComponent<Button>();
        correctButton.interactable = true;  
        // Rozpoczêcie zgadywania liczby
        GuessNumber();
    }


    public void setResponseCorrect()
    {
        infoText.text = "Twoja liczba to: " + guessedNumber;

    }


    void GuessNumber()
    {
        // Wyœwietlenie zgadywanej liczby w polu tekstowym
        infoText.text = "Czy zgad³em liczbê? " + guessedNumber;
        // Oczekiwanie na odpowiedŸ od drugiej osoby

    }

    public void SetResponseGreater()
    {
        minRange = guessedNumber + 1;
        guessedNumber = (minRange + maxRange) / 2; // Algorytm Binarny
        GuessNumber();
    }

    public void SetResponseSmaller()
    {
        maxRange = guessedNumber - 1;
        guessedNumber = (minRange + maxRange) / 2;
        GuessNumber();
    }
}