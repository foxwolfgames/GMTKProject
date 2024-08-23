namespace FWGameLib.InProject.AudioSystem
{
    /// <summary>
    /// A list of all possible sounds in the game.
    /// This enum should be edited per-project that uses FWGameLib.
    /// </summary>
    public enum Sounds
    {
        // Music: title screen music
        MUSIC_TITLE,

        // SFX: Button click
        SFX_UI_BUTTON_CLICK,

        // SFX: Button hover
        SFX_UI_BUTTON_HOVER,

        // SFX: Slider value changed
        SFX_UI_SLIDER_CHANGED,
    
        // SFX: Intro area crowd ambience
        SFX_AMBIENCE_INTRO_AREA_CROWD,
    
        // SFX: Pick up item
        SFX_GAMEPLAY_PICKUP_ITEM,
    
        // SFX: Holding loop
        SFX_GAMEPLAY_PICKUP_HOLDING,
    
        // SFX: Throw item
        SFX_GAMEPLAY_PICKUP_THROW,
    
        // SFX: Drop item
        SFX_GAMEPLAY_PICKUP_DROP,
    
        // SFX: Arena crowd ambience
        SFX_AMBIENCE_ARENA_CROWD,
    
        // Music: Game tutorial music
        MUSIC_GAME_TUTORIAL,
    
        // Music: Game phase 0 music
        MUSIC_GAME_PHASE_0,
    
        // Music: Game over explicit (unused)
        MUSIC_GAME_OVER_EXPLICIT,
    
        // SFX: Arena bridge lowering
        SFX_ARENA_BRIDGE_LOWERING,
    
        // SFX: Press tutorial red button
        SFX_GAMEPLAY_RED_BUTTON_PRESS,
    
        // Voice lines: Announcer while idling in lobby
        VOICE_ANNOUNCER_LOBBY_IDLE,
    
        // Voice lines: Announcer when entering arena
        VOICE_ANNOUNCER_ENTER_ARENA,
    
        // Voice lines: Announcer while in tutorial
        VOICE_ANNOUNCER_TUTORIAL_IDLE,
    
        // Voice lines: Announcer when entering lobby
        VOICE_ANNOUNCER_ENTER_LOBBY,
    
        // Music: Boss phase music
        MUSIC_BOSS_PHASE_1_INTRO,
        MUSIC_BOSS_PHASE_1_LOOP,
        MUSIC_BOSS_PHASE_2_INTRO,
        MUSIC_BOSS_PHASE_2_LOOP,
        MUSIC_BOSS_PHASE_3_INTRO,
        MUSIC_BOSS_PHASE_3_LOOP,
    
        MUSIC_VICTORY,
        SFX_FAILURE,
        VOICE_ANNOUNCER_SURVIVAL_ENTRY,
        VOICE_ANNOUNCER_FAILURE
    }
}