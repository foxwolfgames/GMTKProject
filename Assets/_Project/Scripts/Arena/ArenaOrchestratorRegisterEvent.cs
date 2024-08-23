public class ArenaOrchestratorRegisterEvent
{
    public ArenaOrchestrator ArenaOrchestrator;
    
    public ArenaOrchestratorRegisterEvent(ArenaOrchestrator arenaOrchestrator)
    {
        ArenaOrchestrator = arenaOrchestrator;
    }
    
    public void Invoke()
    {
        ScaleGame.Instance.EventRegister.InvokeArenaOrchestratorRegisterEvent(this);
    }
}