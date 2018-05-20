using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] Transform spriteTransform;

    private TowerState currentState;

    private void SetState(TowerState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
    }

    private void Start()
    {
        SetState(new TowerIdle());
    }
}