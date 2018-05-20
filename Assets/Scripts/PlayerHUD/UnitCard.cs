using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitCard : MonoBehaviour {

    [SerializeField] Image icon;
    Image background;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] TextMeshProUGUI armorText;

    private void Awake()
    {
        background = GetComponent<Image>();
    }

    public void Initialize(Unit unit)
    {
        icon.sprite = unit.Type.icon;
        RefreshStats(unit.Stats);
        unit.onStatsChanged += RefreshStats;
    }

    void RefreshStats(UnitStats stats)
    {
        healthText.text = "Health: " + stats.Health.ToString();
        damageText.text = "Damage: " + stats.Damage.ToString();
        armorText.text = "Armor :" + stats.Armor.ToString();
    }

    public void SetFocused(bool on)
    {
        if (on)
            background.color = Color.blue;
        else
            background.color = Color.black;
    }
}