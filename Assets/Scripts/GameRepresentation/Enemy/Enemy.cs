using Game.Logic;
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
    public abstract void Die();
    protected void Start()
    {
        TransferRewardScore = Score;
    }
}
