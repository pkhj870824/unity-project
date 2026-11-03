using UnityEngine;
using TMPro;
using System.Collections;

public class GameOverWindow : GenericWindow
{
    public TMP_Text leftStatsLabel;
    public TMP_Text rightStatsLabel;
    public TMP_Text leftStatsValue;
    public TMP_Text rightStatsValue;
    public TMP_Text textTotalScore;

    private int[] scores = new int[6];
    private int totalScore;
    private Coroutine scoreCoroutine;

    public override void Open()
    {
        base.Open();

        if (scoreCoroutine != null)
        {
            StopCoroutine(scoreCoroutine);
        }

        scoreCoroutine = StartCoroutine(CoResetScores());
    }

    public override void Close()
    {
        if (scoreCoroutine != null)
        {
            StopCoroutine(scoreCoroutine);
            scoreCoroutine = null;
        }

        base.Close();
    }

    IEnumerator CoResetScores()
    {
        for (int i = 0; i < scores.Length; ++i)
        {
            scores[i] = Random.Range(0, 1000);
        }

        totalScore = Random.Range(0, 100000000);

        leftStatsLabel.text = string.Empty;
        rightStatsLabel.text = string.Empty;
        leftStatsValue.text = string.Empty;
        rightStatsValue.text = string.Empty;
        textTotalScore.text = "000000000";

        for (int i = 0; i < scores.Length; ++i)
        {
            yield return new WaitForSeconds(0.5f);

            TMP_Text lable = i < 3 ? leftStatsLabel : rightStatsLabel;
            TMP_Text value = i < 3 ? leftStatsValue : rightStatsValue;

            lable.text += $"STAT {i + 1}\n";
            value.text += $"{scores[i]:D4}\n";
        }

        float duration = 1.5f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float t = elapsed / duration;

            int value = (int)Mathf.Lerp(0f, totalScore, t);

            textTotalScore.text = $"{value:D9}";

            yield return null;
        }

        textTotalScore.text = $"{totalScore:D9}";
        scoreCoroutine = null;
    }

    public void OnNext()
    {
        manager.Open(Windows.Start);
    }
}