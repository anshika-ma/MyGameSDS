using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Script1 player;
    public PlayerHealth ph;
    public Slider PlayerSlider;
    public Slider EnemySlider;
    public Manager manage;
    private HealthEnemy enemy;
    void Start()
    {
        if (manage == null)
        {
            Debug.LogError("Manager not assigned!");
            enabled = false;
        }
        if (manage == null || manage.CurrentEnemy == null)
        {
            Debug.LogError("Manager or CurrentEnemy not set!");
            return;
        }
        enemy = manage.CurrentEnemy;
        PlayerSlider.maxValue=ph.MaxHealth;
        EnemySlider.maxValue=enemy.HealthMax;
    }

    void Update()
    {
        if (player.current != Script1.PlayerState.Combat) return;

        if (manage.CurrentEnemy != null)
        {
            enemy = manage.CurrentEnemy;
            EnemySlider.maxValue = Mathf.Max(enemy.HealthMax, 1); 
            EnemySlider.value = enemy.HealthLeft;
        }

        PlayerSlider.value = ph.CurrentHealth;
    }

}
