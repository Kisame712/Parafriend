using UnityEngine;
using System;
public class PoisonEffectUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private AudioClip maxPoisonSound;
    private Animator poisonEffectAnim;

    private void Awake()
    {
        poisonEffectAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        PoisonSystem poisonSystem = player.GetPoisonSystem();

        poisonSystem.OnPoisonMaxed += PoisonSystem_OnPoisonMaxed;
        poisonSystem.OnPoisonSucked += PoisonSystem_OnPoisonSucked;
        
    }

    private void PoisonSystem_OnPoisonMaxed(object sender, EventArgs e)
    {
        poisonEffectAnim.SetTrigger("poisoned");
        EffectSoundManager.Instance.PlaySoundEffect(maxPoisonSound);
    }

    private void PoisonSystem_OnPoisonSucked(object sender, EventArgs e)
    {
        poisonEffectAnim.SetTrigger("sucked");
    }
}
