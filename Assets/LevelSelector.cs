using UnityEngine;

public class LevelSelector : MonoBehaviour {

    public SceneFader sceneFader;

	public void SelectLevel(string level)
    {
        sceneFader.FadeTo(level);
    }
}
