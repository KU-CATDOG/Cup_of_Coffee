using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneClickEvent : MonoBehaviour
{
    public SaveLoad saveLoad;
    public GameTime gameTime;
    public GameObject pauseBGPanel;
    public GameObject pausePanel;
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

    private bool isPaused = false;

    private void Start()
    {
        //saveLoad.Save(1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PlayClickSound();

        isPaused = true;

        pauseBGPanel.SetActive(true);
        pausePanel.SetActive(true);

        gameTime.isTimePassing = false;
    }

    public void Resume()
    {
        PlayClickSound();

        isPaused = false;

        pauseBGPanel.SetActive(false);
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        loadPanel.SetActive(false);

        gameTime.isTimePassing = true;
    }

    #region --Load--
    public void ClickLoadButton()
    {
        PlayClickSound();

        pausePanel.SetActive(false);
        loadPanel.SetActive(true);

        saveFileCount = SaveSystem.GetSaveFileCount();
        loadPanelPageMaxIndex = (saveFileCount - 1) / 6;

        RefreshLoadPanel();
    }

    // When user click Back Button in Options Panel
    public void ClickLoadBackButton()
    {
        PlayClickSound();

        pausePanel.SetActive(true);
        loadPanel.SetActive(false);
    }

    public void LoadSaveFile(int saveIndex)
    {
        saveLoad.Load(saveIndex + 1);

        gameTime.dayCounter.text = "Day : " + gameTime.day.ToString();
        gameTime.clock.text = gameTime.hour.ToString("00") + ":" + gameTime.minute.ToString("00");

        ChangeOutside.instance.InitiateOutside();
        Resume();
    }

    public void ClickNextButton()
    {
        PlayClickSound();

        if (loadPanelPageIndex < loadPanelPageMaxIndex)
        {
            loadPanelPageIndex++;

            RefreshLoadPanel();
        }
    }

    public void ClickPrevButton()
    {
        PlayClickSound();

        if (loadPanelPageIndex > 0)
        {
            loadPanelPageIndex--;

            RefreshLoadPanel();
        }
    }

    private void RefreshLoadPanel()
    {
        for (int i = 5; i >= 0; i--)
        {
            if (saveFileButtons[i] == null) continue;
            else Destroy(saveFileButtons[i]);
        }

        for (int i = loadPanelPageIndex * 6; i < saveFileCount; i++)
        {
            if (i >= loadPanelPageIndex * 6 + 6) break;
            GameObject newButton = Instantiate(loadButtonPrefab, loadPanelTransform);
            int temp = i;
            newButton.GetComponent<Button>().onClick.AddListener(() => LoadSaveFile(temp));

            int index = i - (loadPanelPageIndex * 6);
            saveFileButtons[index] = newButton;

            newButton.transform.position = loadPanelTransform.position;
            float xPos = (index % 2 == 0) ? -450f : 450f;
            float yPos = 320f - ((index / 2) * 270f);
            newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);

            Text text = newButton.GetComponentInChildren<Text>();
            text.text = "Save " + (i + 1);
        }
    }
    #endregion


    #region --Options--
    // When user click Options Button
    public void ClickOptionsButton()
    {
        PlayClickSound();

        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);

        bgmScrollBar.value = SoundManager.Instance.GetBGMVolume();
        sfxScrollBar.value = SoundManager.Instance.GetSFXVolume();

        if (Screen.fullScreen)
        {
            fullscreenButton.interactable = false;
            windowButton.interactable = true;
        }
        else
        {
            fullscreenButton.interactable = true;
            windowButton.interactable = false;
        }
    }

    // When user click Back Button in Options Panel
    public void ClickOptionsBackButton()
    {
        PlayClickSound();

        pausePanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    // When user click BGM Down Button
    public void ClickBGMDownButton()
    {
        PlayClickSound();

        if (bgmScrollBar.value >= 0.1f)
        {
            bgmScrollBar.value -= 0.1f;
        }
        else
        {
            bgmScrollBar.value = 0;
        }

        SoundManager.Instance.SetBGMVolume(bgmScrollBar.value);
    }

    // When user click BGM Up Button
    public void ClickBGMUpButton()
    {
        PlayClickSound();

        if (bgmScrollBar.value <= 0.9f)
        {
            bgmScrollBar.value += 0.1f;
        }
        else
        {
            bgmScrollBar.value = 1;
        }

        SoundManager.Instance.SetBGMVolume(bgmScrollBar.value);
    }

    // When user click SFX Down Button
    public void ClickSFXDownButton()
    {
        PlayClickSound();

        if (sfxScrollBar.value >= 0.1f)
        {
            sfxScrollBar.value -= 0.1f;
        }
        else
        {
            sfxScrollBar.value = 0;
        }

        SoundManager.Instance.SetSFXVolume(sfxScrollBar.value);
    }

    // When user click SFX Up Button
    public void ClickSFXUpButton()
    {
        PlayClickSound();

        if (sfxScrollBar.value <= 0.9f)
        {
            sfxScrollBar.value += 0.1f;
        }
        else
        {
            sfxScrollBar.value = 1;
        }

        SoundManager.Instance.SetSFXVolume(sfxScrollBar.value);
    }

    // When user click Fullscreen or Window Button
    // Switch the active of two buttons
    public void ChangeVideoScreenType()
    {
        PlayClickSound();

        if (fullscreenButton.interactable)
        {   
            fullscreenButton.interactable = false;
            windowButton.interactable = true;
            Screen.fullScreen = true;
        }
        else
        {    
            fullscreenButton.interactable = true;
            windowButton.interactable = false;
            Screen.fullScreen = false;
        }
    }
    #endregion

    public void MainMenu()
    {
        PlayClickSound();

        SceneManager.LoadScene("StartScene");
    }

    public void PlayClickSound()
    {
        SoundManager.Instance.PlaySFXSound("click");
    }
}
