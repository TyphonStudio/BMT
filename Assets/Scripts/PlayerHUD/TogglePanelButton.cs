using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TogglePanelButton : MonoBehaviour {

    public GameObject toToggle;

    public Sprite onSprite;
    public Sprite offSprite;

    private Button button;
    private Image image;

    protected virtual void ToggleActive()
    {
        bool isActive = toToggle.activeInHierarchy;

        toToggle.SetActive(!isActive);

        if (isActive)
            image.sprite = onSprite;
        else
            image.sprite = offSprite;
    }

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        button.onClick.AddListener(ToggleActive);
    }

    private void OnDisable()
    {
        button.onClick.RemoveAllListeners();
    }
}