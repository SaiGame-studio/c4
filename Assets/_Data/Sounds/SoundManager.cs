using UnityEngine;

public class SoundManager : SaiMonoBehaviour
{
    [SerializeField] protected SoundName backgroundMusic = SoundName.LastStand;
    [SerializeField] protected MusicCtrl background;
    [SerializeField] protected SoundSpawnerCtrl ctrl;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.StartMusicBackground();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundSpawnerCtrl();
    }

    protected virtual void LoadSoundSpawnerCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = GameObject.FindAnyObjectByType<SoundSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSoundSpawnerCtrl", gameObject);
    }

    protected virtual void StartMusicBackground()
    {
        
    }
}
