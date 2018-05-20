using System.Collections.Generic;
using UnityEngine;

public class SpawnUnitsPanel : MonoBehaviour {

    [SerializeField]
    GameObject cardPrefab;
    [SerializeField]
    ButtonColors cardColors;

    public UnitTypeCard SelectedCard { get; private set; }
    public List<UnitType> availableTypes;

    [SerializeField]
    PlayerUnitSpawner pus;
    [SerializeField]
    PlayerInput pi;

    void CreateCard(UnitType type)
    {
        var card = Instantiate(cardPrefab, transform).GetComponent<UnitTypeCard>();

        card.Init(type);
        card.OnSelected += Select;
        card.OnDragEnd += Spawn;
    }

    void Spawn(UnitTypeCard card, Vector3 screenPos)
    {
        pus.SpawnInCell(pi.GetCellUnder(screenPos), card.Type);
    }

    private void Start()
    {
        foreach (var type in availableTypes)
        {
            CreateCard(type);
        }
    }

    void Select(UnitTypeCard card)
    {
        if(SelectedCard != null)
        {
            SelectedCard.GetDeselected(cardColors.normal);
        }

        SelectedCard = card;

        SelectedCard.GetSelected(cardColors.selected);
    }
}