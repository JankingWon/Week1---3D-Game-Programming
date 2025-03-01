﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.Patrols {
    public class Diretion {
        public const int UP = 0;
        public const int DOWN = 2;
        public const int LEFT = -1;
        public const int RIGHT = 1;
    }

    public class FenchLocation {
        public const float FenchHori = 12.42f;
        public const float FenchVertLeft = -3.0f;
        public const float FenchVertRight = 3.0f;
    }

    public interface IUserAction {
        void heroMove(int dir);
    }

    public interface IAddAction {
        void addRandomMovement(GameObject sourceObj, bool isActive);
        void addDirectMovement(GameObject sourceObj);
    }

    public interface IGameStatusOp {
        int getHeroStandOnArea();
        void heroEscapeAndScore();
        void patrolHitHeroAndGameover();
    }

    public class SceneController : System.Object, IUserAction, IAddAction, IGameStatusOp {
        private static SceneController instance;
        private GameModel myGameModel;
        private GameEventManager myGameEventManager;

        public static SceneController getInstance() {
            if (instance == null)
                instance = new SceneController();
            return instance;
        }

        internal void setGameModel(GameModel _myGameModel) {
            if (myGameModel == null) {
                myGameModel = _myGameModel;
            }
        }

        internal void setGameEventManager(GameEventManager _myGameEventManager) {
            if (myGameEventManager == null) {
                myGameEventManager = _myGameEventManager;
            }
        }
        
        public void heroMove(int dir) {
            myGameModel.heroMove(dir);
        }
        public void addRandomMovement(GameObject sourceObj, bool isActive) {
            myGameModel.addRandomMovement(sourceObj, isActive);
        }

        public void addDirectMovement(GameObject sourceObj) {
            myGameModel.addDirectMovement(sourceObj);
        }
        
        public int getHeroStandOnArea() {
            return myGameModel.getHeroStandOnArea();
        }

        public void heroEscapeAndScore() {
            myGameEventManager.heroEscapeAndScore();
        }

        public void patrolHitHeroAndGameover() {
            myGameEventManager.patrolHitHeroAndGameover();
        }
    }
}

