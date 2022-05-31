using Game.Logic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject gameOverPanel;

    private SceneReloader reloader;

    private void OnEnable()
    {
        reloader = new SceneReloader();

        player.PlayerDead += OnPlayerDead;
    }

    private void OnDisable()
    {
        player.PlayerDead -= OnPlayerDead;
    }

    private void OnPlayerDead()
    {
        GameOver();
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void ReloadSceneOnClick()
    {
        reloader.ReloadScene();
    }

}
