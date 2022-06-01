using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text score;

    public int RewardScore { get; private set; }

    private int currentRewardScore;

    public event UnityAction<int> RewardScoreChanged;

    private void Update()
    {
        CorrectionCurrentRewardScore();
    }

    public void AddRewardScore(int transferRewardScore)
    {
        RewardScore += transferRewardScore;
        RewardScoreChanged?.Invoke(RewardScore);
    }

    private void CorrectionCurrentRewardScore()
    {
        if (currentRewardScore != RewardScore)
        {
            currentRewardScore = RewardScore;

            SetDisplayScore();
        }
    }

    private void SetDisplayScore()
    {
        score.text = currentRewardScore.ToString();
    }

}
