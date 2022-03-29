using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Neues Game Event", menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    private readonly IList<GameEventListener> _events = new List<GameEventListener>();

    // Hier werden alle listener in dieser Liste ausgeführt
    public void Raise()
    {
        // Liste wird rückwärts aufgerufen
        for (var i = _events.Count - 1; i > 0; i--)
        {
            _events[i].OnEventRaised();
        }
    }

    // Hier wird ein Event in die Liste _events hinzugefügt/entfernt
    public void Register(GameEventListener listener)
    {
        _events.Add(listener);
    }
    public void Unregister(GameEventListener listener)
    {
        _events.Remove(listener);
    }
}
