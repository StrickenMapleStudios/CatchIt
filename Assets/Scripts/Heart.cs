using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    private Image _image;

    private void Awake() {
        _image = GetComponent<Image>();
    }

    public void LoseHeart() {
        _image.enabled = false;
    }

    public void AddHeart() {
        _image.enabled = true;
    }
}
