using UnityEngine;
using UnityEngine.UI;
using System;
public class PoisonBarUI : MonoBehaviour
{
    [SerializeField] private Image poisonBar;
    [SerializeField] private PoisonSystem poisonSystem;


    private void Start()
    {
        UpdatePoisonBar();
        poisonSystem.OnPoisonIncreased += OnPoisonSystem_PosionIncreased;
        poisonSystem.OnPoisonSucked += OnPosionSystem_PoisonSucked;
    }


    private void UpdatePoisonBar()
    {
        poisonBar.fillAmount = poisonSystem.GetPoisonNormalized();
    }

    private void OnPoisonSystem_PosionIncreased(object sender, EventArgs e)
    {
        UpdatePoisonBar();
    }

    private void OnPosionSystem_PoisonSucked(object sender, EventArgs e)
    {
        UpdatePoisonBar();
    }

}
