using UnityEngine;

public class MainMenu : MonoBehaviour
{
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