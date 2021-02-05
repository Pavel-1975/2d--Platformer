using TMPro;
using UnityEngine;

public class UILives : MonoBehaviour
{
    [SerializeField] private TMP_Text _iives;

    public void Lives(int live)
    {
        _iives.text = "Жизни: "+live.ToString();
    }
}
