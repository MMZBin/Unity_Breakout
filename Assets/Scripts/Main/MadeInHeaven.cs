using Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//‰Á‘¬
public class MadeInHeaven : MonoBehaviour
{

    public void Press()
    {
        IsUsing = true;
    }

    public void Release()
    {
        IsUsing = false;
        _outOfTime = false;

        _sliderImage.color = Color.white;
    }

    private void Start()
    {
        _manager = GameObject.Find("Manager").GetComponent<Manager>();

        _slider = GetComponent<Slider>();
        _slider.maxValue = INTERVAL;
        _slider.value = 0;
    }

    private void Update()
    {
        if (IsUsing) { return; }
        _slider.value += Time.deltaTime;
    }

    public bool IsReady
    {
        get
        {
            if (IsUsing)
            {
                if (!_outOfTime && _slider.value > 0.1f)
                {
                    _sliderImage.color = Color.red;

                    _slider.value -= Time.deltaTime * 8; //4”{‚Ì‘¬“x‚ÅŽc—Ê‚ðŒ¸‚ç‚·
                    return true;
                }
                else
                {
                    _outOfTime = true;
                }
            }

            _sliderImage.color = Color.white;

            return false;
        }
    }

    public bool IsUsing { get; set; } = false;

    [SerializeField] private Image _sliderImage;

    private const int INTERVAL = 8;

    private Slider _slider;
    private bool _outOfTime;

    private Manager _manager;
}
