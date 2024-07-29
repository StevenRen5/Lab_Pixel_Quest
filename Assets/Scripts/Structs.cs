using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structs
{
    public struct SoundEffects
    {
        public const string coin = "Coin";
        public const string heart = "Heart";
        public const string death = "Dearh";
        public const string checkpoint = "Checkpoint";
    }
    public struct Tags
    {
        public const string deathTag = "Death";
        public const string healthTag = "Health";
        public const string coinTag = "Coin";
        public const string respawnTag = "Respawn";
        public const string finishTag = "Finish";
        public const string respawnColPoint = "Point";
    }

    public struct UI
    {
        public const string heartImage = "HeartImage";
        public const string coinText = "CoinText";
        public const string coins = "Coins";
        public const string panel = "Panel";
        public const string sfxSlider = "SFXSlider";
        public const string musicSlider = "MusicSlider";

    }

    public struct Scenes
    {
        public const string menu = "MenuLevel";
        public const string firstLevel = "TestLevel";
    }

    public struct Mixers
    {
        public const string sfxVolume = "SFXVolume";
        public const string musicVolume = "MusicVolume";
    }
}
