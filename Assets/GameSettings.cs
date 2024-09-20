using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public Slider ballSpeedSlider;
    public Slider paddleSizeSlider;
    public Slider matchDurationSlider;

    public static float ballSpeed = 10f;
    public static float paddleSize = 1f;
    public static float matchDuration = 5f;

    void Start()
    {
        ballSpeedSlider.value = ballSpeed;
        paddleSizeSlider.value = paddleSize;
        matchDurationSlider.value = matchDuration;
    }

    public void SaveSettings()
    {
        ballSpeed = ballSpeedSlider.value;
        paddleSize = paddleSizeSlider.value;
        matchDuration = matchDurationSlider.value;
    }
}
