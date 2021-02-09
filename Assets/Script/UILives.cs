using TMPro;
using UnityEngine;

public class UILives : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _iives;

    private void OnEnable()
    {
        _player.ScoreChangedLives += ShowLives;
    }

    private void OnDisable()
    {
        _player.ScoreChangedLives -= ShowLives;
    }

    private void ShowLives(int live)
    {
        _iives.text = "Жизни: " + live.ToString();
    }
}
