using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KanColle
{
    public class XMLSettings
    {
        #region 変数

        private bool _agree;

        private int _formAlgo = 1;

        private bool _checkUpdate;
        private bool _allowUpdate;
        private bool _showTimer;
        private bool _moveTimer;

        private int _formSizeX = 0;
        private int _formSizeY = 0;
        private int _offsetX = 0;
        private int _offsetY = 0;

        private bool _twitter_auth;
        private string _twitter_key = "null";
        private string _twitter_secret = "null";
        private string _twitter_token = "null";
        private string _twitter_t_secret = "null";

        private bool _playSound;
        private string _soundPath1;

        private string _name1_2;
        private string _name1_3;
        private string _name1_4;

        private DateTime _datetime1_2;
        private DateTime _datetime1_3;
        private DateTime _datetime1_4;
        private DateTime _datetime2_1;
        private DateTime _datetime2_2;
        private DateTime _datetime2_3;
        private DateTime _datetime2_4;
        private DateTime _datetime3_1;
        private DateTime _datetime3_2;
        private DateTime _datetime3_3;
        private DateTime _datetime3_4;

        #endregion

        #region プロパティ

        public bool agree
        {
            get { return _agree; }
            set { _agree = value; }
        }

        public int formAlgo
        {
            get { return _formAlgo; }
            set { _formAlgo = value; }
        }

        public bool checkUpdate
        {
            get { return _checkUpdate; }
            set { _checkUpdate = value; }
        }

        public bool allowUpdate
        {
            get { return _allowUpdate; }
            set { _allowUpdate = value; }
        }

        public bool showTimer
        {
            get { return _showTimer; }
            set { _showTimer = value; }
        }

        public bool moveTimer
        {
            get { return _moveTimer; }
            set { _moveTimer = value; }
        }

        public int formSizeX
        {
            get { return _formSizeX; }
            set { _formSizeX = value; }
        }

        public int formSizeY
        {
            get { return _formSizeY; }
            set { _formSizeY = value; }
        }

        public int offsetX
        {
            get { return _offsetX; }
            set { _offsetX = value; }
        }

        public int offsetY
        {
            get { return _offsetY; }
            set { _offsetY = value; }
        }

        public bool twitter_auth
        {
            get { return _twitter_auth; }
            set { _twitter_auth = value; }
        }

        public string twitter_key
        {
            get { return _twitter_key; }
            set { _twitter_key = value; }
        }

        public string twitter_secret
        {
            get { return _twitter_secret; }
            set { _twitter_secret = value; }
        }

        public string twitter_token
        {
            get { return _twitter_token; }
            set { _twitter_token = value; }
        }

        public string twitter_t_secret
        {
            get { return _twitter_t_secret; }
            set { _twitter_t_secret = value; }
        }

        public bool playSound
        {
            get { return _playSound; }
            set { _playSound = value; }
        }

        public string soundPath1
        {
            get { return _soundPath1; }
            set { _soundPath1 = value; }
        }

        public string name1_2
        {
            get { return _name1_2; }
            set { _name1_2 = value; }
        }

        public string name1_3
        {
            get { return _name1_3; }
            set { _name1_3 = value; }
        }

        public string name1_4
        {
            get { return _name1_4; }
            set { _name1_4 = value; }
        }

        public DateTime datetime1_2
        {
            get { return _datetime1_2; }
            set { _datetime1_2 = value; }
        }

        public DateTime datetime1_3
        {
            get { return _datetime1_3; }
            set { _datetime1_3 = value; }
        }

        public DateTime datetime1_4
        {
            get { return _datetime1_4; }
            set { _datetime1_4 = value; }
        }

        public DateTime datetime2_1
        {
            get { return _datetime2_1; }
            set { _datetime2_1 = value; }
        }

        public DateTime datetime2_2
        {
            get { return _datetime2_2; }
            set { _datetime2_2 = value; }
        }

        public DateTime datetime2_3
        {
            get { return _datetime2_3; }
            set { _datetime2_3 = value; }
        }

        public DateTime datetime2_4
        {
            get { return _datetime2_4; }
            set { _datetime2_4 = value; }
        }

        public DateTime datetime3_1
        {
            get { return _datetime3_1; }
            set { _datetime3_1 = value; }
        }

        public DateTime datetime3_2
        {
            get { return _datetime3_2; }
            set { _datetime3_2 = value; }
        }

        public DateTime datetime3_3
        {
            get { return _datetime3_3; }
            set { _datetime3_3 = value; }
        }

        public DateTime datetime3_4
        {
            get { return _datetime3_4; }
            set { _datetime3_4 = value; }
        }

        #endregion
    }
}
