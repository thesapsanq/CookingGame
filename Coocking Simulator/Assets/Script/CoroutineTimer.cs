using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoroutineTimer : MonoBehaviour
{
    public static float time;
    [SerializeField] private Text timerText;

    private float _timeLeft = 0f;

    [SerializeField] private GameObject panelAfterGame;

    [SerializeField] private Text winCondition;

    public static string winOrLose;

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void Start()
    {
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format(" Оставшееся время: {0:00}:{1:00}", minutes, seconds);

        if (_timeLeft == 0)
        {
            winOrLose = "Вы проиграли";
            panelAfterGame.SetActive(true);
            winCondition.text = winOrLose;
        }
        else if (GameGontroller.isAllPersonHasOrder)
        {
            panelAfterGame.SetActive(true);
            winCondition.text = winOrLose;
            GameGontroller.isAllPersonHasOrder = false;
        }

    }

}