using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class TransferPoints : MonoBehaviour
{
    public TextMeshProUGUI displayPlayerScore;

    public void Awake()
    {
        displayPlayerScore.text = ScoreCounter.scoreValue.ToString();
    }
}

     
