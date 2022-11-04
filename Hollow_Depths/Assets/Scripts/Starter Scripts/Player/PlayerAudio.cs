using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    //Here is where you can add more Audioclips if you want 
    [Header("Audio Clips for the Player")]
    [Header("Walk")]
    public AudioClip WalkAudioClip;
    public bool LoopWalkAudio = false;
    [Range(0, 1)]
    public float WalkVolumeLevel = 1;

    [Header("Attack")]
    public AudioClip AttackAudioClip;
    public bool LoopAttackAudio = false;
    [Range(0, 1)]
    public float AttackVolumeLevel = 1;

    [Header("Death")]
    public AudioClip DeathAudioClip;
    public bool LoopDeathAudio = false;
    [Range(0, 1)]
    public float DeathVolumeLevel = 1;

    [Header("Jump")]
    public AudioClip JumpAudioClip;
    public bool LoopJumpAudio = false;
    [Range(0, 1)]
    public float JumpVolumeLevel = 1;

    [Header("Collect")]
    // I added these
    public AudioClip CollectAudioClip;
    public bool LoopCollectAudio = false;
    [Range(0, 1)]
    public float CollectVolumeLevel = 1;

    [Header("Damage")]
    public AudioClip DamageAudioClip;
    public bool LoopDamageAudio = false;
    [Range(0, 1)]
    public float DamageVolumeLevel = 1;

    [Header("Breathing")]
    public AudioClip BreathingAudioClip;
    public bool LoopBreathingAudio = false;
    [Range(0, 1)]
    public float BreathingVolumeLevel = 1;

    //And here is where you should create the respective AudioSource
    [HideInInspector] public AudioSource WalkSource;
    [HideInInspector] public AudioSource AttackSource;
    [HideInInspector] public AudioSource DeathSource;
    [HideInInspector] public AudioSource JumpSource;

    [HideInInspector] public AudioSource CollectSource;
    [HideInInspector] public AudioSource DamageSource;
    [HideInInspector] public AudioSource BreathingSource;
    //The whole [HideInInspector] thing just makes it so that way you can't see these public variables in editor

    void Start()
    {
        SetUpAudio();
    }

    //Here is where you can add more audio sources and the like
    void SetUpAudio()
    {
        //First you have to make a new GameObject with a name
        GameObject WalkGameObject = new GameObject("WalkAudioSource");
        GameObject AttackGameObject = new GameObject("AttackAudioSource");
        GameObject DeathGameObject = new GameObject("DeathAudioSource");
        GameObject JumpGameObject = new GameObject("JumpAudioSource");

        GameObject CollectGameObject = new GameObject("CollectAudioSource"); //collection
        GameObject DamageGameObject = new GameObject("DamageAudioSource"); //loose health
        GameObject BreathingGameObject = new GameObject("BreathingAudioSource"); //Breathing under water

        //Next you have to Assign the parent so it's all organized
        AssignParent(WalkGameObject);
        AssignParent(AttackGameObject);
        AssignParent(DeathGameObject);
        AssignParent(JumpGameObject);

        AssignParent(CollectGameObject);
        AssignParent(DamageGameObject);
        AssignParent(BreathingGameObject);

        //Then you have to add the actual audiosource to each gameobject
        WalkSource = WalkGameObject.AddComponent<AudioSource>();
        AttackSource = AttackGameObject.AddComponent<AudioSource>();
        DeathSource = DeathGameObject.AddComponent<AudioSource>();
        JumpSource = DeathGameObject.AddComponent<AudioSource>();

        CollectSource = CollectGameObject.AddComponent<AudioSource>();
        DamageSource = DamageGameObject.AddComponent<AudioSource>();
        BreathingSource = BreathingGameObject.AddComponent<AudioSource>();

        //And finally you assign the clip to the audio source
        WalkSource.clip = WalkAudioClip;
        AttackSource.clip = AttackAudioClip;
        DeathSource.clip = DeathAudioClip;
        JumpSource.clip = JumpAudioClip;

        CollectSource.clip = CollectAudioClip;
        DamageSource.clip = DamageAudioClip;
        BreathingSource.clip = BreathingAudioClip;

        //And here is just where we assign the global volume level, you can make these individualized if you want
        WalkSource.volume = WalkVolumeLevel;
        AttackSource.volume = AttackVolumeLevel;
        DeathSource.volume = DeathVolumeLevel;
        JumpSource.volume = JumpVolumeLevel;

        CollectSource.volume = CollectVolumeLevel;
        DamageSource.volume = DamageVolumeLevel;
        BreathingSource.volume = BreathingVolumeLevel;

        WalkSource.loop = LoopWalkAudio;
        AttackSource.loop = LoopAttackAudio;
        DeathSource.loop = LoopDeathAudio;
        JumpSource.loop = LoopJumpAudio;

        CollectSource.loop = LoopCollectAudio;
        DamageSource.loop = LoopDamageAudio;
        BreathingSource.loop = LoopBreathingAudio;
    }

    //Just a helper function that assigns whatever object as a child of this gameObject
    void AssignParent(GameObject obj)
    {
        obj.transform.parent = transform;
    }
}
