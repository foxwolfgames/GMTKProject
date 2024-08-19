// Boilerplate from: https://game.courses/bots-ai-statemachines/

public interface IState
{
    void Tick();
    void OnEnter();
    void OnExit();
}