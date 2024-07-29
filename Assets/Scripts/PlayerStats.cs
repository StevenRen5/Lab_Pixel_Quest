using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // allows us to switch between different scenes

public class PlayerStats : MonoBehaviour
{ // variables
    private Rigidbody2D _rigidbody2D; // interactivity (applies physics)
    private AudioSourceController _audioSourceController; // reference to the audio script
    private UIController _UIController;

    public Transform _respawnPoint; // where the player will come back when died

    public int _playerLife = 3; // player life tracker
    private float _maxHealth = 3.0f; // max health
    public int _playerCoin = 0; // player coin tracker
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSourceController = GameObject.FindAnyObjectByType<AudioSourceController>(); // finds the AudioSourceController (AUDIO)
        _UIController = GameObject.FindAnyObjectByType<UIController>(); // use UI controller
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); // interactivity (applies physics)
    }

    private void OnTriggerEnter2D(Collider2D collision) // collisions with different objects
    {
        string colTag = collision.tag;

        switch(colTag)  // similar to if statement but does everything within { } by doing case
        {
            case Structs.Tags.deathTag:
                {
                    _rigidbody2D.velocity = Vector2.zero; // player touches something that kills then, they stop moving
                    transform.position = _respawnPoint.position;  // moves player to respawn point
                    _playerLife--; // death occurs subtract life by 1
                    _UIController.HeartImageUpdate(_playerLife/_maxHealth); // calc the value
                    _audioSourceController.PlaySFX(Structs.SoundEffects.death); // DEATH AUDIO
                    if (_playerLife <= 0) //player life <= 0
                    {
                        string SceneName = SceneManager.GetActiveScene().name; // get us the name of the scene currently in
                        SceneManager.LoadScene(SceneName); // reloads into the scene currently in
                    }
                    return;
                }

            case Structs.Tags.healthTag:
                {
                    if(_playerLife >= 3) // player player heart >= 3, heart will not be collected but saved for later
                    {
                        return;
                    }

                    _playerLife++; // increases player life count by 1
                    _UIController.HeartImageUpdate(_playerLife / _maxHealth);
                    _audioSourceController.PlaySFX(Structs.SoundEffects.heart); // HEART AUDIO
                    Destroy(collision.gameObject); // Destroys heart after player touches it
                    return;

                }

            case Structs.Tags.coinTag:
                {

                    _playerCoin++; // increases player coin count by 1
                    _UIController.CoinTextUpdate(_playerCoin); // updates coin count
                    _audioSourceController.PlaySFX(Structs.SoundEffects.coin); // audiosource controller plays sound effects when player touched the coin (COIN AUDIO)
                    Destroy(collision.gameObject); // Destroys coin after player touches it
                    return;

                }

            case Structs.Tags.respawnTag:
                {

                    // Saves the collision points location to thee respawn transform
                    _respawnPoint = collision.gameObject.transform.Find(Structs.Tags.respawnTag).transform;
                    _audioSourceController.PlaySFX(Structs.SoundEffects.checkpoint); // CHECKPOINT AUDIO
                    return;

                }

            case Structs.Tags.finishTag:
                {
                    string nextLevel = collision.GetComponent<EndLevel>().nextLevel; // variable attached here
                    SceneManager.LoadScene(nextLevel); //player walks into this obj. Unity will look for a level (next or go back to previous)
                    return;

                }
        }

    }
}
