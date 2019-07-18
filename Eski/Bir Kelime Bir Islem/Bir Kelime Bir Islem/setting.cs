using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Xml;

namespace Bir_Kelime_Bir_Islem
{
    public class setting
    {
       
        bool useArduino = false; //wether arduino is used or not
        string ArduinoPort = "COM1"; // what port is the arduino on
        bool useSettingsFromGames = true; //Should the program use settings from pre prepared games
        bool useAutoGames = false;//Should the app automatically load a pre prepared game
        string AutoGamePath = ""; // Where is this auto game
        int soundType = 0; // Master sound 
        bool[] muteThis = { false, false, false, false }; //Mute which sounds
        string[] soundPath = { "", "", "", "" }; //For custom sounds: where are the sound files
        int time = 30; //How long should the timer be
        private XmlDocument settingXml = new XmlDocument(); //the config file
        private string path = Environment.GetEnvironmentVariable("appdata") + @"\Bir Kelime Bir İşlem\settings.xml"; //path of the config file
        private SoundPlayer animesound = new SoundPlayer(Properties.Resources.animationSound);//Soundplayer for animation sound
        private SoundPlayer addSound = new SoundPlayer(Properties.Resources.addPointsSound);//Soundplayer for points sound
        private SoundPlayer timeSound = new SoundPlayer(Properties.Resources.timeRanOut);//SoundPlayer for playing the time ran out sound
        private SoundPlayer timeBeep = new SoundPlayer(Properties.Resources.beep);
        private SoundPlayer customAnimeSound;//Sound Player for playing custom Animation Sounds
        private SoundPlayer customAddPointsSound;//Sound Player for playing custom point sounds
        private SoundPlayer customTimeRanOutSound;//Sound Player for playing time ran out sounds.
        private SoundPlayer customTimeBeep;
        iConsoleLibrary.iConsole gameConsole = controlForm.gameConsole;

        public setting()
        {
            loadFromPreset();
        }

        /// <summary>
        /// Loads the settings from config file
        /// </summary>
        private void loadFromPreset()
        {
            try
            {
                if (!File.Exists(path)) updateSettings();
                settingXml.Load(path);
                XmlNode arduinoNode = settingXml.SelectSingleNode("settings/arduino");
                XmlNode usePrePreparedSettingsNode = settingXml.SelectSingleNode("settings/prePreparedGameSettings");
                XmlNode autoGameNode = settingXml.SelectSingleNode("settings/autogames");
                XmlNode addPointsSoundNode = settingXml.SelectSingleNode("settings/addPointsSound");
                XmlNode animationSoundNode = settingXml.SelectSingleNode("settings/animationSound");
                XmlNode timeSoundNode = settingXml.SelectSingleNode("settings/timeSound");
                XmlNode timeBeepNode = settingXml.SelectSingleNode("settings/timeBeep");
                XmlNode timingNode = settingXml.SelectSingleNode("settings/time");

                setUseArduino(bool.Parse(arduinoNode.Attributes["use"].InnerText));
                setArduinoPort(arduinoNode.Attributes["port"].InnerText);

                setUseSettingsFromGames(bool.Parse(usePrePreparedSettingsNode.Attributes["use"].InnerText));

                setUseAutoGames(bool.Parse(autoGameNode.Attributes["use"].InnerText));
                setAutoGamePath(autoGameNode.InnerText);

                bool[] s = { bool.Parse(addPointsSoundNode.Attributes["mute"].InnerText), bool.Parse(animationSoundNode.Attributes["mute"].InnerText), bool.Parse(timeSoundNode.Attributes["mute"].InnerText), bool.Parse(timeBeepNode.Attributes["mute"].InnerText) };
                setMuteThis(s);
                int si = int.Parse(addPointsSoundNode.Attributes["type"].InnerText);
                setSoundType(si);
                string[] ssi =
                {
                addPointsSoundNode.InnerText,
                animationSoundNode.InnerText,
                timeSoundNode.InnerText,
                timeBeepNode.InnerText
                };
                setSoundPath(ssi);

                setTime(int.Parse(timingNode.InnerText));
                gameConsole.writeLine("[Settings] Config Loaded");
            }
            catch
            {
                updateSettings(); 
            }
        }

        /// <summary>
        /// updates the config with the fresh settings
        /// </summary>
        public void updateSettings()
        {
            gameConsole.writeLine("[Settings] Updating Config File");
            XmlNode arduinoNode = settingXml.SelectSingleNode("settings/arduino");
            XmlNode usePrePreparedSettingsNode = settingXml.SelectSingleNode("settings/prePreparedGameSettings");
            XmlNode autoGameNode = settingXml.SelectSingleNode("settings/autogames");
            XmlNode addPointsSoundNode = settingXml.SelectSingleNode("settings/addPointsSound");
            XmlNode animationSoundNode = settingXml.SelectSingleNode("settings/animationSound");
            XmlNode timeSoundNode = settingXml.SelectSingleNode("settings/timeSound");
            XmlNode timeBeepNode = settingXml.SelectSingleNode("settings/timeBeep");
            XmlNode timingNode = settingXml.SelectSingleNode("settings/time");

            retry:
            try
            {
                arduinoNode.Attributes["use"].InnerText = getUseArduino().ToString();
                arduinoNode.Attributes["port"].InnerText = getArduinoPort().ToString();

                usePrePreparedSettingsNode.Attributes["use"].InnerText = getUseSettingsFromGames().ToString();

                autoGameNode.Attributes["use"].InnerText = getUseAutoGames().ToString();
                autoGameNode.InnerText = getAutoGamePath();

                addPointsSoundNode.Attributes["mute"].InnerText = getMuteThis()[0].ToString();
                addPointsSoundNode.Attributes["type"].InnerText = getSoundType().ToString();
                addPointsSoundNode.InnerText = getSoundPath()[0];

                animationSoundNode.Attributes["mute"].InnerText = getMuteThis()[1].ToString();
                animationSoundNode.Attributes["type"].InnerText = getSoundType().ToString();
                animationSoundNode.InnerText = getSoundPath()[1];

                timeSoundNode.Attributes["mute"].InnerText = getMuteThis()[2].ToString();
                timeSoundNode.Attributes["type"].InnerText = getSoundType().ToString();
                timeSoundNode.InnerText = getSoundPath()[2];

                timeBeepNode.Attributes["mute"].InnerText = getMuteThis()[3].ToString();
                timeBeepNode.Attributes["type"].InnerText = getSoundType().ToString();
                timeBeepNode.InnerText = getSoundPath()[3];

                timingNode.InnerText = getTime().ToString();
                gameConsole.writeLine("[Settings] Config updated succesfully.");
            }
            catch
            {
                gameConsole.writeLine("[Settings] Config Update Failure, remaking config just to be safe...");
                settingXml.RemoveAll();
                settingXml.AppendChild(settingXml.CreateElement("settings"));
                XmlElement arduinoElement = settingXml.CreateElement("arduino");
                arduinoElement.SetAttribute("port", "");
                arduinoElement.SetAttribute("use", "");
                XmlElement usePrePreparedElemetn = settingXml.CreateElement("prePreparedGameSettings");
                usePrePreparedElemetn.SetAttribute("use", "");
                XmlElement useautoGameElelemt = settingXml.CreateElement("autogames");
                useautoGameElelemt.SetAttribute("use", "");
                XmlElement poitnsElement = settingXml.CreateElement("addPointsSound");
                poitnsElement.SetAttribute("type", "");
                poitnsElement.SetAttribute("mute", "");
                XmlElement animationElement = settingXml.CreateElement("animationSound");
                animationElement.SetAttribute("type", "");
                animationElement.SetAttribute("mute", "");
                XmlElement timeSoundElement = settingXml.CreateElement("timeSound");
                timeSoundElement.SetAttribute("type", "");
                timeSoundElement.SetAttribute("mute", "");
                XmlElement beepElement = settingXml.CreateElement("timeBeep");
                beepElement.SetAttribute("type", "");
                beepElement.SetAttribute("mute", "");
                XmlElement timeElemetn = settingXml.CreateElement("time");
                arduinoNode = arduinoElement;
                usePrePreparedSettingsNode = usePrePreparedElemetn;
                autoGameNode = useautoGameElelemt;
                addPointsSoundNode = poitnsElement;
                animationSoundNode = animationElement;
                timeSoundNode = timeSoundElement;
                timeBeepNode = beepElement;
                timingNode = timeElemetn;
                settingXml.SelectSingleNode("settings").AppendChild(arduinoNode);
                settingXml.SelectSingleNode("settings").AppendChild(usePrePreparedSettingsNode);
                settingXml.SelectSingleNode("settings").AppendChild(autoGameNode);
                settingXml.SelectSingleNode("settings").AppendChild(addPointsSoundNode);
                settingXml.SelectSingleNode("settings").AppendChild(animationSoundNode);
                settingXml.SelectSingleNode("settings").AppendChild(timeSoundElement);
                settingXml.SelectSingleNode("settings").AppendChild(timeBeepNode);
                settingXml.SelectSingleNode("settings").AppendChild(timingNode);
                goto retry;
            }
            settingXml.Save(path);
            loadFromPreset();
        }

        #region Setters
        public void setUseArduino(bool s) { useArduino = s; gameConsole.writeLine("[Settings] Use Arduino: " + s.ToString()); }        
        public void setArduinoPort(string s) { ArduinoPort = s; gameConsole.writeLine("[Settings] Arduino Port: " + s.ToString()); }
        public void setUseSettingsFromGames(bool s) { useSettingsFromGames = s; gameConsole.writeLine("[Settings] Use PPG Settings: " + s.ToString()); }
        public void setUseAutoGames(bool s) { useAutoGames = s; gameConsole.writeLine("[Settings] Use Auto PPG: " + s.ToString()); }
        public void setAutoGamePath(string s) { AutoGamePath = s; gameConsole.writeLine("[Settings] Auto PPG Path: " + controlForm.ShortenPath(s.ToString(), 50)); }
        public void setSoundType(int s) { soundType = s; gameConsole.writeLine("[Settings] Sound Type: " + s.ToString()); }
        public void setMuteThis(bool[] s) { muteThis = s; gameConsole.writeLine("[Settings] Muted Sounds: " + "Animation " + s[0].ToString() + ", Poitns " + s[1].ToString() + ", Time Buzzer " + s[2].ToString() + ", Time Beep " + s[3].ToString()); }
        public void setSoundPath(string[] s)
        {
            soundPath = s;
            if (File.Exists(soundPath[0])) customAnimeSound = new SoundPlayer(soundPath[0]);
            if (File.Exists(soundPath[1]))customAddPointsSound = new SoundPlayer(soundPath[1]);
            if (File.Exists(soundPath[2])) customTimeRanOutSound = new SoundPlayer(soundPath[2]);
            if (File.Exists(soundPath[3])) customTimeBeep = new SoundPlayer(soundPath[3]);
            gameConsole.writeLine("[Settings] Custom Sound Paths: " + "Animation " + controlForm.ShortenPath(s[0], 50) + ", Poitns " + controlForm.ShortenPath(s[1], 50) + ", Time Buzzer " + controlForm.ShortenPath(s[2], 50) + " Time Beep " + controlForm.ShortenPath(s[3],50));
        }
        public void setTime(int s) { time = s; gameConsole.writeLine("[Settings] Counter Lenght: " + s.ToString()); }
        #endregion

        #region Getters
        public bool getUseArduino() { return useArduino; }
        public string getArduinoPort() { return ArduinoPort; }
        public bool getUseSettingsFromGames() { return useSettingsFromGames; }
        public bool getUseAutoGames() { return useAutoGames; }
        public string getAutoGamePath() { return AutoGamePath; }
        public int getSoundType() { return soundType; }
        public bool[] getMuteThis() { return muteThis; }
        public string[] getSoundPath() { return soundPath; }
        public int getTime() { return time; }
        #endregion

        /// <summary>
        /// Plays the Animation Sound
        /// </summary>
        public void playAnime()
        {
            try
            {
                if (!muteThis[0])
                { 
                    if (getSoundType() == 0) animesound.Play();
                    if (getSoundType() == 1) Console.Beep(250, 150);
                    if (getSoundType() == 2 && customAnimeSound != null) customAnimeSound.Play();
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// Plays the points add sound
        /// </summary>
        public void playAdd()
        {
            try //Tries
            {
                if (!muteThis[1])
                {
                    if (getSoundType() == 0) addSound.Play();
                    if (getSoundType() == 1) Console.Beep(350, 90);
                    if (getSoundType() == 2 && customAddPointsSound != null) customAddPointsSound.Play();
                }
            }
            catch { throw; }
        }

        /// <summary>
        /// Plays the time ran out buzzer
        /// </summary>
        public void playTimeRanOutBuzzer()
        {
            try
            {
                if (!muteThis[1])
                {
                    if (getSoundType() == 0) timeSound.Play();
                    if (getSoundType() == 1) Console.Beep(500, 1000);
                    if (getSoundType() == 2 && customTimeRanOutSound != null) customTimeRanOutSound.Play();
                }
            }
            catch { throw; }
        }

        public void playBeep()
        {
            try
            {
                if (!muteThis[3])
                {
                    if (getSoundType() == 0) timeBeep.Play();
                    if (getSoundType() == 1) Console.Beep(550, 500);
                    if (getSoundType() == 3 && customTimeBeep !=null ) customTimeBeep.Play();
                }
            }
            catch { throw; }
        }
        
    }

}
