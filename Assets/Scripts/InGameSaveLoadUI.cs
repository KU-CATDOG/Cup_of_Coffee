using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSaveLoadUI : MonoBehaviour
{
    public GameObject chooseSaveLoadPanel;
    public GameObject panel;
    public Transform panelTransform;

    public GameObject loadButtonPrefab;

    public SaveLoad saveLoad;
    public GameTime gameTime;

    private bool isSavePanel = false;

    private int saveFileCount = 0;
    private int panelPageIndex = 0;
    private int loadPanelPageMaxIndex = 0;
    private int savePanelPageMaxIndex = 0;
    private GameObject[] saveFileButtons = new GameObject[6];

    private void Start()
    {
        // --Load--
        //saveFileCount = 15;  // �׽�Ʈ������ ������ ���ڸ� ���� -> ����� ���̺����� ������ ������ ��
        saveFileCount = SaveSystem.GetSaveFileCount();
        loadPanelPageMaxIndex = (saveFileCount - 1) / 6;
        savePanelPageMaxIndex = saveFileCount / 6;

        chooseSaveLoadPanel.SetActive(false);
        panel.SetActive(false);
    }

    public void OpenSaveLoadPanel()
    {
        panel.SetActive(false);
        chooseSaveLoadPanel.SetActive(true);

        panelPageIndex = 0;
    }

    public void ClickSaveButton()
    {
        chooseSaveLoadPanel.SetActive(false);
        panel.SetActive(true);

        saveFileCount = SaveSystem.GetSaveFileCount();
        loadPanelPageMaxIndex = (saveFileCount - 1) / 6;
        savePanelPageMaxIndex = saveFileCount / 6;

        isSavePanel = true;
        RefreshPanel(isSavePanel);
    }

    public void ClickLoadButton()
    {
        chooseSaveLoadPanel.SetActive(false);
        panel.SetActive(true);

        saveFileCount = SaveSystem.GetSaveFileCount();
        loadPanelPageMaxIndex = (saveFileCount - 1) / 6;
        savePanelPageMaxIndex = saveFileCount / 6;

        isSavePanel = false;
        RefreshPanel(isSavePanel);
    }

    // When user click Back Button in Options Panel
    public void ClickBackButton()
    {
        // ���� ȭ�鿡 �ִ� ���̺����� ��ư���� ����
        for (int i = 5; i >= 0; i--)
        {
            if (saveFileButtons[i] == null) continue;

            Destroy(saveFileButtons[i]);
        }

        panelPageIndex = 0;

        panel.SetActive(false);
        chooseSaveLoadPanel.SetActive(true);
    }

    public void ClickCloseButton()
    {
        chooseSaveLoadPanel.SetActive(false);
        gameTime.isTimePassing = true;
        ChangeOutside.instance.InitiateOutside();
    }

    // ���̺� ���� ����
    public void Save(int saveIndex)
    {
        // saveIndex�� 0���� ������ (ex. save1.txt == 0��° ���̺�����) -> ������ �ҷ��ö��� saveIndex�� 1�� ���� ���� ����� ��
        saveLoad.Save(saveIndex + 1);

        //panel.SetActive(false);
        //gameTime.isTimePassing = true;
    }

    // ���̺� ���� �ҷ�����
    public void LoadSaveFile(int saveIndex)
    {
        // saveIndex�� 0���� ������ (ex. save1.txt == 0��° ���̺�����) -> ������ �ҷ��ö��� saveIndex�� 1�� ���� ���� ����� ��
        saveLoad.Load(saveIndex + 1);

        // gameTime�� �ҷ��� ������ �ݿ�
        gameTime.dayCounter.text = "Day : " + gameTime.day.ToString();

        panel.SetActive(false);
        gameTime.isTimePassing = true;
        ChangeOutside.instance.InitiateOutside();
    }

    public void ClickNextButton()
    {
        int maxIndex = isSavePanel ? savePanelPageMaxIndex : loadPanelPageMaxIndex;
        if (panelPageIndex < maxIndex)
        {
            panelPageIndex++;

            RefreshPanel(isSavePanel);
        }
    }

    public void ClickPrevButton()
    {
        if (panelPageIndex > 0)
        {
            panelPageIndex--;

            RefreshPanel(isSavePanel);
        }
    }

    private void RefreshPanel(bool isSavePanel)
    {
        //Transform panelTransform = isSavePanel ? savePanelTransform : loadPanelTransform;
        int fileCount = isSavePanel ? saveFileCount + 1 : saveFileCount;

        // ���� ȭ�鿡 �ִ� ���̺����� ��ư���� ����
        for (int i = 5; i >= 0; i--)
        {
            if (saveFileButtons[i] == null) continue;

            Destroy(saveFileButtons[i]);
        }

        // ���� ȭ���� ���̺����� ��ư���� ����� (�ִ� 6��)
        for (int i = panelPageIndex * 6; i < fileCount; i++)
        {
            if (i >= panelPageIndex * 6 + 6) break;
            GameObject newButton = Instantiate(loadButtonPrefab, panelTransform);
            int temp = i;
            if (!isSavePanel)
            {
                newButton.GetComponent<Button>().onClick.AddListener(() => LoadSaveFile(temp));
            }
            else
            {
                newButton.GetComponent<Button>().onClick.AddListener(() => Save(temp));
            }

            int index = i - (panelPageIndex * 6);
            saveFileButtons[index] = newButton;

            // ��ư���� ��ġ ����
            newButton.transform.position = panelTransform.position;
            float xPos = (index % 2 == 0) ? -450f : 450f;
            float yPos = 320f - ((index / 2) * 270f);
            newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);

            // ��ư���� �ؽ�Ʈ ����
            Text text = newButton.GetComponentInChildren<Text>();
            text.text = "Save " + (i + 1);

            // ���� ���� ��ư�� �� ����
            if (isSavePanel && i == fileCount - 1)
            {
                ColorBlock colorBlock = newButton.GetComponent<Button>().colors;
                colorBlock.normalColor = new Color(217f / 255f, 237f / 255f, 146f / 255f);
                colorBlock.highlightedColor = new Color(207f / 255f, 227f / 255f, 136f / 255f);
                colorBlock.pressedColor = new Color(167f / 255f, 187f / 255f, 96f / 255f);
                colorBlock.selectedColor = new Color(207f / 255f, 227f / 255f, 136f / 255f);
                colorBlock.disabledColor = new Color(167f / 255f, 187f / 255f, 96f / 255f, 0.5f);
                colorBlock.fadeDuration = 0;
                newButton.GetComponent<Button>().colors = colorBlock;

                colorBlock.fadeDuration = 0.1f;
                newButton.GetComponent<Button>().colors = colorBlock;
            }
        }
    }
}
