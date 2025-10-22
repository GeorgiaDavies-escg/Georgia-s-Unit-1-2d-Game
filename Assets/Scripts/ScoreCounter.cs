using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreCounter : MonoBehaviour
{

    private TextMeshProUGUI scoreCounterText;
    public int scoreValue;

    private void Awake()
    {
        PlayerScript.BurgerPickedUp += RunCo1;
        scoreCounterText = GetComponent<TextMeshProUGUI>();
    }
        


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounterText.text = scoreValue.ToString();
    }

    private IEnumerator Pulse()
    {

        for (float i = 1f; i <= 1.2f; i += 0.05f)
        {
            scoreCounterText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreCounterText.rectTransform.localScale = new Vector3(1.01f, 1.01f, 1.01f);

        scoreValue += 100;

    }

    public void RunCo1()
    {
        StartCoroutine(Pulse());
    }

    private void OnDestroy()
    {
        PlayerScript.BurgerPickedUp -= RunCo1;
    }
}
