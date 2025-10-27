using UnityEngine;
using System;

public class Parasite : MonoBehaviour
{
    [SerializeField] private AudioClip suckSound;
    private Animator parasiteAnimator;

    private void Awake()
    {
        parasiteAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        Player player = FindFirstObjectByType<Player>();
        
        if(player.TryGetComponent<SuckAction>(out SuckAction suckAction))
        {
            suckAction.OnSuckStarted += OnSuckStarted_PlaySuckAnimation;
        }
    }

    private void OnSuckStarted_PlaySuckAnimation(object sender, EventArgs e)
    {
        EffectSoundManager.Instance.PlaySoundEffect(suckSound);
        parasiteAnimator.SetTrigger("suck");
    }

}
