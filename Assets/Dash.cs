using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] GameObject dashEffect;

    private float dashSpeedMultiplier = 4f;

    private float dashDuration = 0.25f;

    private float timer = 0f;

    public bool isDashing = false;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > dashDuration)
        {
            dashEffect.SetActive(false);
            GameManager.Instance.ResetScrollSpeed();
            isDashing = false;
            PlayerManager.Instance.animator.SetTrigger("DashEnd");
        }
    }

    public void ExecuteDash()
    {
        dashEffect.SetActive(true);
        PlayerManager.Instance.animator.SetTrigger("Dash");
        isDashing = true;
        timer = 0f;
        GameManager.Instance.SetScrollSpeed(GameManager.Instance.GetScrollSpeed() * dashSpeedMultiplier);
    }
}
