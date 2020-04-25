
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class playersetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] compomentstodisable;

    private void start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < compomentstodisable.Length; i++)
            {
                compomentstodisable[i].enabled = false;
            }
        }
    }
}
