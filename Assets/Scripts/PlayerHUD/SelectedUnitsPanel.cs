using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnitsPanel : MonoBehaviour
{

    public Player player;
    public GameObject unitCardPrefab;

    public KeyCode focusOnNext;
    public int unitUnderFocus = -1;

    public delegate void NewFocusAction(Unit unit);
    public NewFocusAction OnNewFocus;

    public delegate void LoseFocusAction();
    public LoseFocusAction OnLoseFocus;

    [SerializeField] Transform content;

    public Dictionary<Unit, UnitCard> allUnitCards = new Dictionary<Unit, UnitCard>();
    List<Unit> units = new List<Unit>();

    private void Awake()
    {
        player.OnPlayerUnitsChanged += ProceedNewSelection;
    }

    private void Update()
    {
        if (Input.GetKeyDown(focusOnNext))
        {
            if (units.Count > 0)
                SetFocusOnNext();
        }
    }

    private void SetFocusOnFirst()
    {
        unitUnderFocus = 0;
        SetFocusOn(units[unitUnderFocus], true);
        OnNewFocus?.Invoke((units[unitUnderFocus]));
    }

    private void SetFocusOnNext()
    {
        SetFocusOn(units[unitUnderFocus], false);

        unitUnderFocus = (unitUnderFocus + 1 < units.Count) ? unitUnderFocus + 1 : 0;

        SetFocusOn(units[unitUnderFocus], true);

        OnNewFocus?.Invoke((units[unitUnderFocus]));
    }

    void ProceedNewSelection(List<Unit> newSelection)
    {
        if (newSelection.Count > 0)
        {
            ClearAllSelection();

            for (int i = 0; i < newSelection.Count; i++)
            {
                CreateCard(newSelection[i]);
            }

            SetFocusOnFirst();
        }
        else
        {
            ClearAllSelection();
            OnLoseFocus?.Invoke();
        }
    }

    void SetFocusOn(Unit unit, bool on)
    {
        UnitCard card;
        allUnitCards.TryGetValue(unit, out card);
        if (card)
            card.SetFocused(on);
    }

    void CreateCard(Unit unit)
    {
        UnitCard card = Instantiate(unitCardPrefab, content).GetComponent<UnitCard>();

        allUnitCards.Add(unit, card);
        units.Add(unit);

        card.Initialize(unit);
        unit.deathAction += DeleteDeadUnitCard;
    }

    void ClearAllSelection()
    {
        foreach (var item in allUnitCards.Values)
        {
            DestroyCardObject(item);
        }

        allUnitCards.Clear();
        units.Clear();
    }

    void DestroyCardObject(UnitCard card)
    {
        Destroy(card.gameObject);
    }

    void DeleteDeadUnitCard(Unit unit)
    {
        UnitCard card;
        allUnitCards.TryGetValue(unit, out card);
        allUnitCards.Remove(unit);
        units.Remove(unit);
        if (card)
            DestroyCardObject(card);
    }
}