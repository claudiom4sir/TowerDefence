using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public SceneFader sceneFader;
    public GameObject levels;
    private Button[] buttons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        buttons = levels.GetComponentsInChildren<Button>();
        if(buttons == null) // used for debug
        {
            Debug.Log("Start() in LevelSelector failed, buttons array is null");
            return;
        }
        for (int i = levelReached; i < buttons.Length; i++)
            buttons[i].interactable = false;
    }

    public void SelectLevel(string level)
    {
        sceneFader.FadeTo(level);
    }

    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
    }
}
