using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneClickEvent : MonoBehaviour {
    public GameObject optionsPanel;
    public GameObject optionsPanel1;
    public GameObject optionsPanel2;
    public Scrollbar bgmScrollBar;
    public Scrollbar sfxScrollBar;
    public Button fullscreenButton;
    public Button windowButton;

    private bool isWindowSelected = true;

    // Initiate
    private void Start() {
        // --Options--
        fullscreenButton.interactable = true;
        windowButton.interactable = false;
        bgmScrollBar.value = 1;
        sfxScrollBar.value = 1;
        optionsPanel1.SetActive(true);
        optionsPanel2.SetActive(false);
        optionsPanel.SetActive(false);
    }


    #region --New Game--
    public void ClickNewGameButton() {
        SceneManager.LoadScene("NewGame");
    }
    #endregion


    #region --Load--
    public void ClickLoadButton() {

    }
    #endregion


    #region --Options--
    // When user click Options Button
    public void ClickOptionsButton() {
        optionsPanel.SetActive(true);
    }

    // When user click Back Button in Options Panel
    public void ClickOptionsBackButton() {
        optionsPanel.SetActive(false);
    }

    // When user click Next Button in Panel 1
    public void ClickNextButtonInPanel1() {
        optionsPanel1.SetActive(false);
        optionsPanel2.SetActive(true);
    }

    // When user click Prev Button in Panel 2
    public void ClickPrevButtonInPanel2() {
        optionsPanel2.SetActive(false);
        optionsPanel1.SetActive(true);
    }

    // When user click BGM Down Button
    public void ClickBGMDownButton() {
        if (bgmScrollBar.value >= 0.1f) {
            bgmScrollBar.value -= 0.1f;
        }
        else {
            bgmScrollBar.value = 0;
        }
    }

    // When user click BGM Up Button
    public void ClickBGMUpButton() {
        if (bgmScrollBar.value <= 0.9f) {
            bgmScrollBar.value += 0.1f;
        }
        else {
            bgmScrollBar.value = 1;
        }
    }

    // When user click SFX Down Button
    public void ClickSFXDownButton() {
        if (sfxScrollBar.value >= 0.1f) {
            sfxScrollBar.value -= 0.1f;
        }
        else {
            sfxScrollBar.value = 0;
        }
    }

    // When user click SFX Up Button
    public void ClickSFXUpButton() {
        if (sfxScrollBar.value <= 0.9f) {
            sfxScrollBar.value += 0.1f;
        }
        else {
            sfxScrollBar.value = 1;
        }
    }

    // When user click Fullscreen or Window Button
    // Switch the active of two buttons
    public void ChangeVideoScreenType() {
        if (fullscreenButton.interactable) {
            fullscreenButton.interactable = false;
            windowButton.interactable = true;
            isWindowSelected = false;
        }
        else {
            fullscreenButton.interactable = true;
            windowButton.interactable = false;
            isWindowSelected = true;
        }
    }
    #endregion


    #region --Exit--
    public void ClickExitButton() {

    }
    #endregion
}
