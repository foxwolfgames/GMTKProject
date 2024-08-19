using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        ScaleGame.Instance.Audio.PlaySound(Sounds.MUSIC_TITLE);
    }
    
    public void Play()
    {
        new PressPlayEvent().Invoke();
    }

    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }
}
