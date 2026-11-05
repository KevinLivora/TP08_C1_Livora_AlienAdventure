using UnityEngine;

public class KeyPickable : Pickable
{
    protected override void OnPicked(GameObject player)
    {
        GameManager.Instance.AddKey();
    }
}
