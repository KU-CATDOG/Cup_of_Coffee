using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        // TODO: 저장된 세이브파일의 개수를 확인해 saveFileCount 변수에 담기
        saveFileCount = 15;  // 테스트용으로 임의의 숫자를 넣음 -> 저장된 세이브파일 개수로 수정할 것
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
        // saveIndex는 0부터 시작함 (ex. save1.txt == 0번째 세이브파일) -> 파일을 불러올때는 saveIndex에 1을 더한 값을 사용할 것
        string saveFileName = "save" + (saveIndex + 1) + ".txt";

        // TODO: 세이브 로드 기능 적용
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
        // 현재 화면에 있는 세이브파일 버튼들을 삭제
        for (int i = 5; i >= 0; i--) {
            if (saveFileButtons[i] == null) continue;
            else Destroy(saveFileButtons[i]);
        }

        // 다음 화면의 세이브파일 버튼들을 재생성 (최대 6개)
        for (int i = loadPanelPageIndex * 6; i < saveFileCount; i++) {
            if (i >= loadPanelPageIndex * 6 + 6) break;
            GameObject newButton = Instantiate(loadButtonPrefab, loadPanelTransform);
            int temp = i;
            newButton.GetComponent<Button>().onClick.AddListener(() => LoadSaveFile(temp));

            int index = i - (loadPanelPageIndex * 6);
            saveFileButtons[index] = newButton;

            // 버튼들의 위치 조정
            newButton.transform.position = loadPanelTransform.position;
            float xPos = (index % 2 == 0) ? -450f : 450f;
            float yPos = 320f - ((index / 2) * 270f);
            newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);

            // 버튼들의 텍스트 변경
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
        if (fullscreenButton.interactable) {    // Window 선택중일때 -> Fullscreen으로 바꿈
            fullscreenButton.interactable = false;
            windowButton.interactable = true;
            Screen.fullScreen = true;
        }
        else {                                  // Fullscreen 선택중일때 -> Window로 바꿈
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
        Application.Quit(); // 어플리케이션 종료
#endif
    }
    #endregion

    #region --Global--
    public void PlayClickSound() {
        SoundManager.Instance.PlaySFXSound("click");
    }
    #endregion
}
