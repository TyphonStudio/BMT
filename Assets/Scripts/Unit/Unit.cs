using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectable, IHaveStats
{
    public UnitType Type { get; private set; }
    public UnitStats Stats { get { return myStats; } set { myStats = value; } }

    [SerializeField]
    UnitStats myStats;

    void SetHealthToMax()
    {
        Debug.Log("set");
    }

    [ContextMenuItem("SetToMax", "SetHealthToMax")]
    public int team;
    public float attackInRange;

    public Unit attackingEnemy;

    public GameObject SelectionCircle { get;
        set; }

    public Traveller Traveller { get; set; }

    public HealthSlider healthSlider;

    public Transform spriteTransform;
    private SpriteRenderer sr;

    private UnitState currentState;

    public bool canMove;

    public System.Action<Unit> deathAction = delegate { };

    Animator myAnimator;

    private void SetState(UnitState state)
    {
        if (currentState != null)
        {
            currentState.OnLeaveState();
        }
        currentState = state;
    }

    void Awake()
    {
        Traveller = GetComponent<Traveller>();
        sr = spriteTransform.GetComponent<SpriteRenderer>();
        myAnimator = spriteTransform.GetComponent<Animator>();
    }

    private void Start()
    {
        SetState(new Idle(this));
        canMove = true;
    }

    private void Update()
    {
        currentState.Tick();
    }

    public void Attack(Unit unit)
    {
        canMove = false;
        attackingEnemy = unit;
        SetState(new Attacking(this, unit));
    }

    public void Move(List<HexCell> path)
    {
        if(canMove)
            SetState(new Moving(this, path));
    }

    public void Stop()
    {
        SetState(new Idle(this));
        canMove = true;
    }

    public float ModifyHealth(float amount)
    {
        if(myStats.Health - amount <= 0)
        {
            Die();
        }
        else
        {
            myStats.Health -= amount;
            healthSlider.SetSlider((myStats.Health / Stats.MaxHealth));
        }

        return myStats.Health;
    }

    public void Die()
    {
        deathAction?.Invoke(this);

        Destroy(healthSlider.gameObject);
        Destroy(gameObject);
    }

    public void ToggleFlip(bool toggle)
    {
        sr.flipX = toggle;
    }

    public void ApplyType(UnitType type)
    {
        Type = type;
        myAnimator.runtimeAnimatorController = type.animatorOverride;

        InitStats(type.defaultStats);

        InitializeAbilities(type);
    }

    private void InitializeAbilities(UnitType type)
    {
        if(type.defaultAbilities.Count > 0)
        {
            foreach (var ability in type.defaultAbilities)
            {
                ability.Initialize(this);
            }
        }
    }

    public void InitStats(UnitStats stats)
    {
        myStats = stats;
        myStats.Health = myStats.MaxHealth;
        myStats.onAnyStatChanged += onStatsChanged;
    }

    public System.Action<UnitStats> onStatsChanged = delegate { };
}