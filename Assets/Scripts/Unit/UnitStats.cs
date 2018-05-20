using UnityEngine;

[System.Serializable]
public struct UnitStats
{
    public System.Action<UnitStats> onAnyStatChanged;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
            onAnyStatChanged?.Invoke(this);
        }
    }

    [SerializeField]
    float health;

    public float MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    [SerializeField]
    float maxHealth;

    public float Damage
    {
        get { return damage; }
        set
        {
            damage = value;
            onAnyStatChanged?.Invoke(this);
        }
    }
    [SerializeField]
    float damage;


    public float Armor
    {
        get { return armor; }
        set
        {
            armor = value;
            onAnyStatChanged?.Invoke(this);
        }
    }

    [SerializeField]
    float armor;

    public float AttackCooldown { get { return attackCooldown; }
    set
        {
            attackCooldown = value;
            onAnyStatChanged?.Invoke(this);
        }
    }

    [SerializeField]
    float attackCooldown;
}