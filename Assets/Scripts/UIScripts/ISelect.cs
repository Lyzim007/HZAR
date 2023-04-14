
using UnityEngine;

public interface ISelect
{
    Vector2 Position();
    void SetAim(bool aim, bool playSound = true);
    void SetSelect(bool select);
}
