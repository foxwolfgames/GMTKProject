using UnityEngine.SceneManagement;

public class IntroState : IState
{
    public void Tick()
    {
        //throw new System.NotImplementedException();
    }

    public void OnEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnExit()
    {
        //throw new System.NotImplementedException();
    }
}