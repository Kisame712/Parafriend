using UnityEngine;
using System;
public class HealImageUI : MonoBehaviour
{
    [SerializeField] private Player player;
    private Animator healImageAnim;
    private void Awake()
    {
        healImageAnim = GetComponent<Animator>();
    }


    private void Start()
    {
        if(player.TryGetComponent<HealAction>(out HealAction healAction))
        {
            healAction.OnHealStarted += OnHealStarted_PlayHealImageAnimation;
        }
    }

    private void OnHealStarted_PlayHealImageAnimation(object sender, EventArgs e)
    {
        healImageAnim.SetTrigger("heal");
    }
}
