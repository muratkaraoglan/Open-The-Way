using UnityEngine.SceneManagement;
using UnityEngine;

public class UI : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        if ( !PlayerPrefs.HasKey("Level") )
        {
            PlayerPrefs.SetInt("Level", 1);
        }

        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    public void OnNextLevelButtonClick()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));

    }
}
