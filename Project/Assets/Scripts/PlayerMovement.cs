using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this is for ui 
using UnityEngine.UI;
//this is for text
using TMPro;
public class PlayerMovement : MonoBehaviour
{
    #region Construct
    [Header("Construct")]
    //the animation reference
    Animator _anim;
    //rigidbody to implement physics
    Rigidbody _rb;
    //slider to make player move 
    [SerializeField] Slider _slider;
    //the invisible wall to make the books dont fall
    [SerializeField] Collider[] _holders;
    //this is the first ui when you join the game i mean the level scene 
    [SerializeField] GameObject _gamePanel;
    //when you win this is the ui
    [SerializeField] GameObject _winPanel;
    //when you lose this is the ui
    [SerializeField] GameObject _losePanel;
    //this is the score text
    public TextMeshProUGUI _scoreText;
    #endregion
    #region Vectors
    [Header("Vectors")]
    //the direction to make playermove
    private Vector3 _movementLocation;

    #endregion

    #region float
    [Header("Floats")]
    //max speed for slider
    [SerializeField] private float _maxSpeedRL;
    //player speed and animation speed
    [SerializeField] float _speed;
    [SerializeField] float _animationSpeed;
    //player max speed
    [SerializeField] float _maxSpeed;
    //just to set the value of disable colliders i disable it ignore it 
    [SerializeField] float startvalue;
    //the value for the slider
    private float _value;
    #endregion
    #region bool
    //to make player stop moving when losing 
    bool _canMove=true;
    #endregion
    #region int
    //score
    [HideInInspector] public int _score=8;
    #endregion

    private void Awake()
    {
        //expalin it before
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponentInChildren<Animator>();
    }
    private void Start()
    {//ignore it 
        Invoke("EnableColliders", startvalue);
        _holders[0].enabled = true;
        _holders[1].enabled = true;
        //sliders value to make the player move depends on it 
        _slider.minValue = _maxSpeedRL * -1;
        _slider.maxValue = _maxSpeedRL;
        _slider.value = 0;
    }
    
    private void Update()
    {
     //playermovement
        _slider.onValueChanged.AddListener((value) => { _speed = value; _animationSpeed = value; });
        _movementLocation = new Vector3(_speed*-1, 0, 0);

    }
    private void FixedUpdate()
    {
        if (_canMove)
        {
            //animationmovement
            _anim.SetFloat("Speed", _animationSpeed);
            //REAL PLAYER MOVEMENT there are real just make he's leg move and there are change of transform this is the real
            _rb.velocity = _movementLocation;
        }
        else
            //make player stop moving
         _anim.SetFloat("Speed", 0);
           
    }
    //ignore it 
    private void EnableColliders()
    {
        _holders[0].enabled = false;
        _holders[1].enabled = false;
    }
    //when player touch the invisible wall he will win
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Win"))
        {
            _winPanel.SetActive(true);
            _gamePanel.SetActive(false);
            _canMove = false;
        }
            
    }

    public void DeadChecker()
    {
        //if the score less than 3 he will lose
        if (_score <= 3)
        {
            _losePanel.SetActive(true);
            _canMove = false;
         
            _gamePanel.SetActive(false);
        }
        else
        {
            //on each book fall the score will count down 
            _score -= 1;
            _scoreText.text = _score.ToString();
        }
    }
}
