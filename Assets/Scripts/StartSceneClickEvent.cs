using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneClickEvent : MonoBehaviour {
    public GameObject optionsPanel;
    public GameObject loadPanel;
    public Scrollbar bgmScrollBar;
    public Scrollbar sfxScrollBar;
    public Button fullscreenButton;
    public Button windowButton;
    public Transform loadPanelTransform;

    public GameObject loadButtonPrefab;

    private int saveFileCount = 0;
    private int loadPanelPageIndex = 0;
    private int loadPanelPageMaxIndex = 0;
    private GameObject[] saveFileButtons = new GameObject[6];

    // Initiate
    private void Start() {
        // --Load--
        // TODO: ����� ���̺������� ������ Ȯ���� saveFileCount ������ ���
        saveFileCount = 15;  // �׽�Ʈ������ ������ ���ڸ� ���� -> ����� ���̺����� ������ ������ ��
        loadPanelPageMaxIndex = (saveFileCount - 1) / 6;        
        loadPanel.SetActive(false);

        // --Options--
        fullscreenButton.interactable = true;
        windowButton.interactable = false;
        bgmScrollBar.value = 1;
        sfxScrollBar.value = 1;
        optionsPanel.SetActive(false);
    }


    #region --New Game--
    public void ClickNewGameButton() {
        SceneManager.LoadScene("NewGameScene");
    }
    #endregion


    #region --Load--
    public void ClickLoadButton() {
        loadPanel.SetActive(true);

        RefreshLoadPanel();
    }

    // When user click Back Button in Options Panel
    public void ClickLoadBackButton() {
        loadPanel.SetActive(false);
    }

    public void LoadSaveFile(int saveIndex) {
        // saveIndex�� 0���� ������ (ex. save1.txt == 0��° ���̺�����) -> ������ �ҷ��ö��� saveIndex�� 1�� ���� ���� ����� ��
        string saveFileName = "save" + (saveIndex + 1) + ".txt";

        // TODO: ���̺� �ε� ��� ����
        Debug.Log(saveFileName);
    }

    public void ClickNextButton() {
        if (loadPanelPageIndex < loadPanelPageMaxIndex) {
            loadPanelPageIndex++;

            RefreshLoadPanel();
        }
    }

    public void ClickPrevButton() {
        if (loadPanelPageIndex > 0) {
            loadPanelPageIndex--;

            RefreshLoadPanel();
        }
    }

    private void RefreshLoadPanel() {
        // ���� ȭ�鿡 �ִ� ���̺����� ��ư���� ����
        for (int i = 5; i >= 0; i--) {
            if (saveFileButtons[i] == null) continue;
            else Destroy(saveFileButtons[i]);
        }

        // ���� ȭ���� ���̺����� ��ư���� ����� (�ִ� 6��)
        for (int i = loadPanelPageIndex * 6; i < saveFileCount; i++) {
            if (i >= loadPanelPageIndex * 6 + 6) break;
            GameObject newButton = Instantiate(loadButtonPrefab, loadPanelTransform);
            int temp = i;
            newButton.GetComponent<Button>().onClick.AddListener(() => LoadSaveFile(temp));

            int index = i - (loadPanelPageIndex * 6);
            saveFileButtons[index] = newButton;

            // ��ư���� ��ġ ����
            newButton.transform.position = loadPanelTransform.position;
            float xPos = (index % 2 == 0) ? -450f : 450f;
            float yPos = 320f - ((index / 2) * 270f);
            newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);

            // ��ư���� �ؽ�Ʈ ����
            Text text = newButton.GetComponentInChildren<Text>();
            text.text = "Save " + (i + 1);
        }
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

    // When user click BGM Down Button
    public void ClickBGMDownButton() {
        if (bgmScrollBar.value >= 0.1f) {
            bgmScrollBar.value -= 0.1f;
        }
        else {
            bgmScrollBar.value = 0;
        }

        SoundManager.Instance.SetBGMVolume(bgmScrollBar.value);
    }

    // When user click BGM Up Button
    public void ClickBGMUpButton() {
        if (bgmScrollBar.value <= 0.9f) {
            bgmScrollBar.value += 0.1f;
        }
        else {
            bgmScrollBar.value = 1;
        }

        SoundManager.Instance.SetBGMVolume(bgmScrollBar.value);
    }

    // When user click SFX Down Button
    public void ClickSFXDownButton() {
        if (sfxScrollBar.value >= 0.1f) {
            sfxScrollBar.value -= 0.1f;
        }
        else {
            sfxScrollBar.value = 0;
        }

        SoundManager.Instance.SetSFXVolume(sfxScrollBar.value);
    }

    // When user click SFX Up Button
    public void ClickSFXUpButton() {
        if (sfxScrollBar.value <= 0.9f) {
            sfxScrollBar.value += 0.1f;
        }
        else {
            sfxScrollBar.value = 1;
        }

        SoundManager.Instance.SetSFXVolume(sfxScrollBar.value);
    }

    // When user click Fullscreen or Window Button
    // Switch the active of two buttons
    public void ChangeVideoScreenType() {
        if (fullscreenButton.interactable) {    // Window �������϶� -> Fullscreen���� �ٲ�
            fullscreenButton.interactable = false;
            windowButton.interactable = true;
            Screen.fullScreen = true;
        }
        else {                                  // Fullscreen �������϶� -> Window�� �ٲ�
            fullscreenButton.interactable = true;
            windowButton.interactable = false;
            Screen.fullScreen = false;
        }
    }
    #endregion


    #region --Exit--
    public void ClickExitButton() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ���ø����̼� ����
#endif
    }
    #endregion

    #region --Global--
    public void PlayClickSound() {
        SoundManager.Instance.PlaySFXSound("click");
    }
    #endregion
}
