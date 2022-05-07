using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
    [SerializeField] protected GameEvent _gameEvent;
    [SerializeField] UnityEvent _unityEvent;

    protected virtual void Awake() => _gameEvent.Register(this);

    void OnDestroy() => _gameEvent.DeRegister(this);

    public void RaiseEvent() => _unityEvent.Invoke();
}
