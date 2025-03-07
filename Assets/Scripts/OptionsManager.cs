using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI moveControlText;
    [SerializeField] TextMeshProUGUI jumpControlText;
    [SerializeField] TextMeshProUGUI doubleJumpControlText;
    [SerializeField] TextMeshProUGUI runControlText;
    [SerializeField] TextMeshProUGUI shootControlText;
    [SerializeField] TextMeshProUGUI changeWeaponControlText;
    [SerializeField] GameObject startButton;
    [SerializeField] GameObject controlsButton;
    [SerializeField] GameObject backToMenuButton;

    private void Start()
    {
        moveControlText.enabled = false;
        jumpControlText.enabled = false;
        doubleJumpControlText.enabled = false;
        runControlText.enabled = false;
        shootControlText.enabled = false;
        changeWeaponControlText.enabled = false;
        backToMenuButton.SetActive(false);
    }

    public void ShowControls()
    {
        titleText.enabled = false;
        controlsButton.SetActive(false);
        startButton.SetActive(false);
        backToMenuButton.SetActive(true);
        moveControlText.enabled = true;
        jumpControlText.enabled = true;
        doubleJumpControlText.enabled = true;
        runControlText.enabled = true;
        shootControlText.enabled = true;
        changeWeaponControlText.enabled = true;
    }

    public void BackToMenu()
    {
        titleText.enabled=true;
        controlsButton.SetActive(true);
        startButton.SetActive(true);
        backToMenuButton.SetActive(false);
        moveControlText.enabled = false;
        jumpControlText.enabled = false;
        doubleJumpControlText.enabled = false;
        runControlText.enabled = false;
        shootControlText.enabled = false;
        changeWeaponControlText.enabled = false;
    }
}
