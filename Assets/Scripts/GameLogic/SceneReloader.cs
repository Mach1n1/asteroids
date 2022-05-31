using UnityEngine.SceneManagement;

namespace Game.Logic
{
    public class SceneReloader
    {
        public void ReloadScene()
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
    }
}
