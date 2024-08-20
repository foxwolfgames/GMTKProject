using UnityEngine;

public class ArenaOrchestrator : MonoBehaviour
{
    public ArenaPlatform platform;
    public ArenaBridge bridge;
    public GameObject player;
    public DialogueController dialogueController;
    
    public void Start()
    {
        new ArenaOrchestratorRegisterEvent(this).Invoke();
        platform.SetPlatformCanRotate(false);
    }
}