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


        startButton.image.enabled = false; // Wy��cz renderowanie obrazka przycisku
        startButton.interactable = false; // Wy��cz interakcj� z przyciskiem
        startButtonObject.SetActive(false); // Wy��cz obiekt przycisku startowego

        Debug.Log("StartGuessing() called");



        // Inicjalizacja pocz�tkowych warto�ci zakresu i liczby
        minRange = 0;
        maxRange = 100;
        guessedNumber = Random.Range(minRange, maxRange + 1);
        


        // W��czenie interakcji z przyciskami "Wi�kszy" i "Mniejszy" 
        Button greaterButton = GameObject.Find("Wi�kszy").GetComponent<Button>();
        greaterButton.interactable = true;

        Button smallerButton = GameObject.Find("Mniejszy").GetComponent<Button>();
        smallerButton.interactable = true;

        Button correctButton = GameObject.Find("Tak").GetComponent<Button>();
        correctButton.interactable = true;  
        // Rozpocz�cie zgadywania liczby
        GuessNumber();
    }


    public void setResponseCorrect()
    {
        infoText.text = "Twoja liczba to: " + guessedNumber;

    }


    void GuessNumber()
    {
        // Wy�wietlenie zgadywanej liczby w polu tekstowym
        infoText.text = "Czy zgad�em liczb�? " + guessedNumber;
        // Oczekiwanie na odpowied� od drugiej osoby

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