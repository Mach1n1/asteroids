using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text score;

    private int currentRewardScore;

    public int RewardScore { get; private set; }
    
    public event UnityAction<int> RewardScoreChanged;

    private void FixedUpdate()
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
