using UnityEngine;

public abstract class State : ScriptableObject
{
    public abstract void Enter(params object[] parameters);
    public abstract void Tick();
    public abstract void FixedTick();

    public abstract void Exit();
}