using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class TempUserData : MonoBehaviour
    {

        private static TempUserData _instance;

        public static TempUserData Instance { get { return _instance; } }

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this);
            }
        }


        public int PlayerHealth { get; set; }

        public Transform currentPosition { get; set; }


        public void SetPlayerHealth(int health)
        {
            PlayerPrefs.SetInt("PlayerHealth", health);
        }


        public void SetCurrentPosition(Transform currentPosition)
        {
            PlayerPrefs.SetFloat("PositionX", currentPosition.position.x);
            PlayerPrefs.SetFloat("PositionY", currentPosition.position.y);
        }
    }
}
