using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    
    [SerializeField] protected int Score;

    public int TransferRewardScore { get; private set; }

    protected Score Reward => FindObjectOfType<Score>();


    protected void AddScore()
    {
        Reward.AddRewardScore(TransferRewardScore);
    }

    protected void Start()
    {
        TransferRewardScore = Score;
    }

    public abstract void Die();
}
