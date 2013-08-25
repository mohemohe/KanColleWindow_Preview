using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using TweetSharp;

namespace KanColle
{
    public class globVal
    {
        #region 一時的な変数

        public static bool moveForm2 = true;

        public static string enseiName;
        public static int enseiTime_hour;
        public static int enseiTime_minute;
        public static int enseiTime_second;
        public static string CurrentVer;

        public static string tmp;

        #endregion

        #region 設定部分の値

        public static bool _agree;

        public static int _formAlgo = 1;

        public static bool _checkUpdate;
        public static bool _allowUpdate;
        public static bool _showTimer;
        public static bool _moveTimer;

        public static int _formSizeX = 0;
        public static int _formSizeY = 0;
        public static int _offsetX = 0;
        public static int _offsetY = 0;

        public static bool _twitter_auth = false;

        public static string _twitter_key;
        public static string _twitter_secret;
        public static string _twitter_token;
        public static string _twitter_t_secret;
        //public static ArrayList _twitter_hashtag = new ArrayList();
        public static ArrayList _twitter_hashtag;

        public static bool _playSound = true;
        public static string _soundPath1;

        public static string _name1_2;
        public static string _name1_3;
        public static string _name1_4;

        public static DateTime _datetime1_2;
        public static DateTime _datetime1_3;
        public static DateTime _datetime1_4;
        public static DateTime _datetime2_1;
        public static DateTime _datetime2_2;
        public static DateTime _datetime2_3;
        public static DateTime _datetime2_4;
        public static DateTime _datetime3_1;
        public static DateTime _datetime3_2;
        public static DateTime _datetime3_3;
        public static DateTime _datetime3_4;

        #endregion

        #region 読み書き

        XMLSettings settings = new XMLSettings();
        XmlSerializer serializer = new XmlSerializer(typeof(XMLSettings));

        public void readSettings()
        {
            try
            {
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + "settings.xml", FileMode.Open);

                settings = (XMLSettings)serializer.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {

            }

            //一般
            _agree = settings.agree;
            _checkUpdate = settings.checkUpdate;
            _allowUpdate = settings.allowUpdate;
            _showTimer = settings.showTimer;
            _moveTimer = settings.moveTimer;

            //レイアウト
            _formAlgo = settings.formAlgo;
            _formSizeX = settings.formSizeX;
            _formSizeY = settings.formSizeY;
            _offsetX = settings.offsetX;
            _offsetY = settings.offsetY;

            //twitter連携
            _twitter_auth = settings.twitter_auth;
            _twitter_key = Encrypt.DecryptString(settings.twitter_key);
            _twitter_secret = Encrypt.DecryptString(settings.twitter_secret);
            _twitter_token = Encrypt.DecryptString(settings.twitter_token);
            _twitter_t_secret = Encrypt.DecryptString(settings.twitter_t_secret);
            _twitter_hashtag = settings.twitter_hashtag;
                //for (int i = 0; i <= settings.twitter_hashtag.Length - 1; i++) _twitter_hashtag.Add(settings.twitter_hashtag[i]);

            //簡易タイマー
            moveForm2 = settings.moveTimer;
            _playSound = settings.playSound;
            _soundPath1 = settings.soundPath1;
            _name1_2 = settings.name1_2;
            _name1_3 = settings.name1_3;
            _name1_4 = settings.name1_4;
            _datetime1_2 = settings.datetime1_2;
            _datetime1_3 = settings.datetime1_3;
            _datetime1_4 = settings.datetime1_4;
            _datetime2_1 = settings.datetime2_1;
            _datetime2_2 = settings.datetime2_2;
            _datetime2_3 = settings.datetime2_3;
            _datetime2_4 = settings.datetime2_4;
            _datetime3_1 = settings.datetime3_1;
            _datetime3_2 = settings.datetime3_2;
            _datetime3_3 = settings.datetime3_3;
            _datetime3_4 = settings.datetime3_4;
        }

        public bool writeSettings()
        {
            //一般
            settings.agree = _agree;
            settings.checkUpdate = _checkUpdate;
            settings.allowUpdate = _allowUpdate;
            settings.showTimer = _showTimer;
            settings.moveTimer = _moveTimer;

            //レイアウト
            settings.formAlgo = _formAlgo;
            settings.formSizeX = _formSizeX;
            settings.formSizeY = _formSizeY;
            settings.offsetX = _offsetX;
            settings.offsetY = _offsetY;

            //twitter連携
            settings.twitter_auth = _twitter_auth;

            if (_twitter_auth == true)
            {
                try
                {
                    settings.twitter_key = Encrypt.EncryptString(_twitter_key);
                    settings.twitter_secret = Encrypt.EncryptString(_twitter_secret);
                    settings.twitter_token = Encrypt.EncryptString(_twitter_token);
                    settings.twitter_t_secret = Encrypt.EncryptString(_twitter_t_secret);
                }
                catch (Exception)
                {
                    
                }
            }
            //try{
            //    for(int i = 3; i <= _twitter_hashtag.Count - 1; i++) settings.twitter_hashtag
            //}
            //catch (Exception)
            //{
            //    
            //}
            settings.twitter_hashtag = _twitter_hashtag;

            //簡易タイマー
            settings.moveTimer = moveForm2;
            settings.playSound = _playSound;
            settings.soundPath1 = _soundPath1;
            settings.name1_2 = _name1_2;
            settings.name1_3 = _name1_3;
            settings.name1_4 = _name1_4;
            settings.datetime1_2 = _datetime1_2;
            settings.datetime1_3 = _datetime1_3;
            settings.datetime1_4 = _datetime1_4;
            settings.datetime2_1 = _datetime2_1;
            settings.datetime2_2 = _datetime2_2;
            settings.datetime2_3 = _datetime2_3;
            settings.datetime2_4 = _datetime2_4;
            settings.datetime3_1 = _datetime3_1;
            settings.datetime3_2 = _datetime3_2;
            settings.datetime3_3 = _datetime3_3;
            settings.datetime3_4 = _datetime3_4;

            try
            {
                FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "\\" + "settings.xml", FileMode.Create);

                serializer.Serialize(fs, settings);
                fs.Close();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
