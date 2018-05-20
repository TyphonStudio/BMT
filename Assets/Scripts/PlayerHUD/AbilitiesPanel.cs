using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Abilities;

public class AbilitiesPanel : MonoBehaviour
{
    public Player player;
    public SelectedUnitsPanel selectedUnitsPanel;

    public GameObject abilityCardPrefab;

    public Unit showForUnit;

    List<AbilityCard> allCards = new List<AbilityCard>();

    private void Awake()
    {
        selectedUnitsPanel.OnNewFocus += ShowAbilities;
        selectedUnitsPanel.OnLoseFocus += ClearAllCards;
    }

    AbilityCard CreateCard(UnitAbility ability)
    {
        var card = Instantiate(abilityCardPrefab, transform).GetComponent<AbilityCard>();

        card.Init(ability);
        return card;
    }

    void ShowAbilities(Unit unit)
    {
        ClearAllCards();

        CreateCardsFor(unit);
    }

    void CreateCardsFor(Unit unit)
    {
        showForUnit = unit;


        if (unit.Type.defaultAbilities.Count > 0)
        {
            for(int i = 0; i < unit.Type.defaultAbilities.Count; i++)
            {
                allCards.Add(CreateCard(unit.Type.defaultAbilities[i]));
            }
            
            unit.deathAction += OnUnitDeath;
        }
    }

    void OnUnitDeath(Unit unit)
    {
        ClearAllCards();
    }

    void ClearAllCards()
    {
        foreach (var card in allCards)
        {
            Destroy(card.gameObject);
        }
        allCards.Clear();

        showForUnit = null;
    }
}