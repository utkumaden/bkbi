using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Xml;

namespace bkbi.Core
{
    public static class SaveLoad
    {
        public static void Load(FileStream fileToOpen)
        {
            switch (Path.GetExtension(fileToOpen.Name))
            {
                case ".bkbi":
                    //Kill the stream to avoid multiple handles
                    fileToOpen.Dispose();
                    Tools.Console.Info("Arşiv bulundu, çıkartılıp yükleniyor.");
                    string tempExtractPath = Environment.GetEnvironmentVariable("temp") + "/bkbi/Load";
                    Directory.CreateDirectory(tempExtractPath);
                    foreach (FileInfo file in new DirectoryInfo(tempExtractPath).GetFiles())
                    {
                        file.Delete();
                    }
                    ZipFile.ExtractToDirectory(fileToOpen.Name, tempExtractPath);
                    string xmlFile = File.ReadAllText(tempExtractPath + "/coreGame.bkbiXml");
                    xmlFile = xmlFile.Replace("##bkbi:tempExtractPath", tempExtractPath);
                    File.WriteAllText(tempExtractPath + "/coreGame.bkbiXml", xmlFile);
                    Load(tempExtractPath + "/coreGame.bkbiXml");
                    break;
                case ".bkbiXml":
                    XMLLoader(fileToOpen);
                    break;
            }
        }
        public static void Load(string pathToFile)
        {
            Load(new FileStream(pathToFile, FileMode.Open));
        }

        static void XMLLoader(FileStream fileToOpen)
        {
            Tools.Console.Info("XML dosyasından yükleniyor:" + fileToOpen.Name + " ...");

            //Open file
            XmlDocument file = new XmlDocument();
            file.Load(fileToOpen);

            Tools.Console.Info("Dosya başarılı bir şekilde açıldı.");

            if (file.InnerXml == string.Empty)
            {
                Tools.Console.Error("Yüklenen dosya boş.");
                throw new FileLoadException("Yüklenen dosya boş.", fileToOpen.Name);
            }

            #region Players

            Tools.Console.Info("Oyuncular yükleniyor...");

            // if players node exists
            if (file.SelectSingleNode("bkbi/players") != null)
            {
                //Counter for how many child nodes there are
                int count = 0;

                #region NodeScanner
                //do this for each of its nodes
                foreach (XmlElement p in file.SelectSingleNode("bkbi/players").ChildNodes)
                {

                    //if it is a "player" node
                    if (p.Name == "player")
                    {
                        //Increase counter
                        count++;

                        //Create a new player
                        Player playerInstance = new Player();
                        Program.ControlPanel.playersListViewBox.Items.Add(playerInstance.menuItem);
                        Tools.Console.Info("Yeni oyuncu eklendi (" + count.ToString() + ")");

                        //Name
                        XmlAttribute nameAttribute = p.Attributes["name"];
                        if (nameAttribute != null && nameAttribute.InnerText != string.Empty)
                        {
                            playerInstance.setName(nameAttribute.InnerText);
                        }
                        else
                        {
                            Tools.Console.Warning("Oyuncunun adı boş veya ad bölümü eksik. Atlandı.");
                        }

                        //inGame
                        XmlAttribute inGameAttribute = p.Attributes["inGame"];
                        if (inGameAttribute != null && inGameAttribute.InnerText != string.Empty)
                        {
                            bool b = true;
                            try
                            {
                                b = bool.Parse(inGameAttribute.InnerText);
                            }
                            catch
                            {
                                Tools.Console.Warning("Oyuncunun oyunda olma değeri hatalı. Oyunda olduğu var sayılıyor.");
                            }
                            finally
                            {
                                playerInstance.setInGame(b);
                            }

                        }
                        else
                        {
                            Tools.Console.Warning("Oyuncunun oyunda olama durumu bölümü eksik veya boş. Oyunda var sayılıyor.");
                            playerInstance.setInGame(true);
                        }

                        //points
                        XmlAttribute pointsAttribute = p.Attributes["points"];
                        if (pointsAttribute != null && pointsAttribute.InnerText != string.Empty)
                        {
                            uint i = 0;
                            try
                            {
                                i = uint.Parse(pointsAttribute.InnerText);
                            }
                            catch
                            {
                                Tools.Console.Warning("Oyuncunun puan verisi hatalı. Puanı 0(sıfır) var sayılıyor.");
                            }
                            finally
                            {
                                if (i != 0) playerInstance.addPoints(i);
                            }
                        }
                        else
                        {
                            Tools.Console.Warning("Oyuncunun puan verisi eksik veya boş. Puanın sıfır var sayılıyor.");
                        }

                        //profile picture
                        XmlAttribute profilePicturePathAttribute = p.Attributes["iconPath"];
                        if (profilePicturePathAttribute != null && profilePicturePathAttribute.InnerText != string.Empty)
                        {
                            string path = profilePicturePathAttribute.InnerText;
                            if (File.Exists(path))
                            {
                                try
                                {
                                    using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(path))
                                    {
                                        playerInstance.setPP(bmp);
                                    }
                                }
                                catch
                                {
                                    Tools.Console.Warning("Yol bir resim dosyasına gitmiyor,dosya bozuk veya desteklenmiyor.");
                                }
                            }
                            else
                            {
                                Tools.Console.Warning("Profil fotoğrafı yolu bir dosyaya varmıyor. Atlandı.");
                            }

                        }

                    }
                    else
                    {
                        Tools.Console.Warning("Bilinmeyen bölüm:" + p.Name + ". Atlandı.");
                    }
                }
                #endregion

                //if no player node is present
                if (count == 0)
                {
                    Tools.Console.Warning("Yüklenicek oyunculara rastlanılmadı.");
                }
                else //if player nodes are present
                {
                    //report how many has been loaded.
                    Tools.Console.Info(count.ToString() + " oyuncu yüklendi.");
                }
            }
            else
            {
                Tools.Console.Warning("Oyuncular bölümü yok!");
            }
            #endregion

            #region Questions
            Tools.Console.Info("Sorular yükleniyor...");

            //if questions node exists
            if (file.SelectSingleNode("bkbi/questions") != null)
            {
                //Counter for how many child nodes there are
                int count = 0;

                //Set the dictionaryPath
                XmlAttribute dictionaryAttribute = file.SelectSingleNode("bkbi/questions").Attributes["dictionaryPath"];
                if (dictionaryAttribute != null && dictionaryAttribute.InnerText != string.Empty)
                {
                    if (File.Exists(dictionaryAttribute.InnerText))
                    {
                        DictionaryWord.changeDictionary(dictionaryAttribute.InnerText);
                    }
                    else
                    {
                        Tools.Console.Warning("Sözlük yolu bir dosyaya varmıyor. Atlanıldı.");
                    }
                }
                else
                {
                    Tools.Console.Warning("Sözlük yolu hanesi boş veya yok. Atlanıldı.");
                }

                #region NodeScanner
                //do this for each node
                foreach (XmlElement q in file.SelectSingleNode("bkbi/questions").ChildNodes)
                {
                    switch (q.Name)
                    {
                        //for userWords
                        #region UserWord
                        case "userWord":

                            Tools.Console.Info("Kullanıcı kelimesi yükleniyor.");

                            UserWord uw = new UserWord();
                            Program.ControlPanel.eqAndWordsListViewBox.Items.Add(uw.menuItem);

                            uw.SetWorth(getWorthFromQuestionXml(q));
                            uw.SetUsed(getUsedFromQuestionXml(q));

                            XmlAttribute wordAttribute = q.Attributes["word"];
                            if (wordAttribute != null && wordAttribute.InnerText != string.Empty)
                            {
                                uw.setUserWord(wordAttribute.InnerText);
                            }
                            else
                            {
                                Tools.Console.Warning("Kullanıcı kelimesinin kelimesi eksik. Atlandı");
                            }

                            count++;

                            break;
                        #endregion

                        //for userEquations
                        #region User Equation
                        case "userEquation":
                            Tools.Console.Info("Kullanıcı işlemi yükleniyor.");

                            UserEquation uq = new UserEquation();
                            Program.ControlPanel.eqAndWordsListViewBox.Items.Add(uq.menuItem);

                            uq.SetWorth(getWorthFromQuestionXml(q));
                            uq.SetUsed(getUsedFromQuestionXml(q));

                            XmlAttribute sumAttribute = q.Attributes["sum"];
                            int sum = 0;
                            if (sumAttribute != null && sumAttribute.InnerText != string.Empty)
                            {
                                try
                                {
                                    sum = int.Parse(sumAttribute.InnerText);
                                }
                                catch
                                {
                                    Tools.Console.Warning("Kullanıcı işleminin toplam değeri hatalı. 0 varsayıldı");
                                }
                            }
                            else
                            {
                                Tools.Console.Warning("Kullanıcı işleminin toplam değeri boş veya yok. 0 varsayıldı");
                            }

                            XmlAttribute numbersAttribute = q.Attributes["numbers"];
                            int[] numbers = new int[6];

                            if (numbersAttribute != null && numbersAttribute.InnerText != string.Empty)
                            {
                                string[] toConvert = numbersAttribute.InnerText.Split(',');
                                for (int i = 0; i < numbers.Length; i++)
                                {
                                    numbers[i] = 0;
                                    try
                                    {
                                        numbers[i] = int.Parse(toConvert[i]);
                                    }
                                    catch
                                    {
                                        Tools.Console.Warning("Kullanici işleminin " + i.ToString() + ". numarası hatalı.");
                                    }
                                }
                            }
                            else
                            {
                                Tools.Console.Warning("Kullanıcı işleminin sayıları eksik veya boş.");
                            }


                            XmlAttribute solutionAttribute = q.Attributes["solution"];
                            string solutionString = "";
                            if (solutionAttribute != null && solutionAttribute.InnerText != string.Empty)
                            {
                                solutionString = solutionAttribute.InnerText;
                            }
                            else
                            {
                                Tools.Console.Warning("Kullanıcı işleminin çözüm bölümü eksik veya boş. Atlanıldı.");
                            }

                            uq.set(sum, solutionString, numbers);

                            count++;

                            break;
                        #endregion

                        // For dictionaryWords
                        #region DictionaryWord
                        case "dictionaryWord":

                            Tools.Console.Info("Sözlük Kelimesi Yükleniyor.");

                            DictionaryWord dw = new DictionaryWord();
                            Program.ControlPanel.eqAndWordsListViewBox.Items.Add(dw.menuItem);

                            dw.SetWorth(getWorthFromQuestionXml(q));
                            dw.SetUsed(getUsedFromQuestionXml(q));

                            count++;

                            break;
                        #endregion

                        //for autoequations
                        #region AutoEquation
                        case "autoEquation":

                            Tools.Console.Info("Otomatik İşlem Yükleniyor.");

                            AutoEquation aq = new AutoEquation();
                            Program.ControlPanel.eqAndWordsListViewBox.Items.Add(aq.menuItem);

                            aq.SetWorth(getWorthFromQuestionXml(q));
                            aq.SetUsed(getUsedFromQuestionXml(q));

                            count++;

                            break;
                        #endregion

                        //for foreign nodes
                        default:
                            Tools.Console.Warning("Bilinmeğen bölüm:" + q.Name);
                            break;
                    }
                }
                #endregion

                //if no questions nodes exist
                if (count == 0)
                {
                    Tools.Console.Warning("Yüklenicek sorulara rastlanmadı.");
                }
                else
                {
                    Tools.Console.Info(count.ToString() + " soru yüklendi.");
                }

            }
            else
            {
                Tools.Console.Warning("Sorular bölümü yok.");
            }
            #endregion

            #region MISC
            #endregion

        }

        static uint getWorthFromQuestionXml(XmlElement node)
        {
            uint points = 0;

            XmlAttribute attrb = node.Attributes["worth"];

            if (attrb != null && attrb.InnerText != string.Empty)
            {
                try
                {
                    points = uint.Parse(attrb.InnerText);
                }
                catch
                {
                    Tools.Console.Warning("Sorunun değer hanesi hatalı. 0 varsayıldı.");
                }
            }
            else
            {
                Tools.Console.Warning("Sorunun değer hanesi yok veya boş. 0 varsayıldı");
            }
            return points;

        }
        static bool getUsedFromQuestionXml(XmlElement node)
        {
            bool used = false;

            XmlAttribute attrb = node.Attributes["used"];

            if(attrb != null && attrb.InnerText != string.Empty)
            {
                try
                {
                    used = bool.Parse(attrb.InnerText);
                }
                catch
                {
                    Tools.Console.Warning("Sorunun kullanılmış hanesi hatalı. Kullanılmadı varsayıldı.");
                }
            }
            else
            {
                Tools.Console.Warning("Sorunun kullanılmış hanesi yok veya boş. Kullanılmadı varsayıldı.");
            }

            return used;
        }

        public static void Save(string filePath)
        {
            string TempWorkDirectory = Environment.GetEnvironmentVariable("temp") + "/bkbi/Save";
            Directory.CreateDirectory(TempWorkDirectory);
            SaveXML(TempWorkDirectory + "/coreGame.bkbiXml");
            ZipFile.CreateFromDirectory(TempWorkDirectory, filePath);
        }

        public static void SaveXML(string filePath)
        {
			//Create new document 
            XmlDocument document = new XmlDocument();
            XmlDeclaration declaration = document.CreateXmlDeclaration("1.0", "UTF-8", "yes");

			//create the root element
            XmlElement rootElement = document.CreateElement("bkbi");
            XmlAttribute fileversionAttribute = document.CreateAttribute("version");
            fileversionAttribute.InnerText = "1.0";
            rootElement.Attributes.Append(fileversionAttribute);

			//Other elements
            XmlElement playersElement = document.CreateElement("players");
            XmlElement questionsElement = document.CreateElement("questions");
            XmlElement miscElement = document.CreateElement("misc");
			
            rootElement.AppendChild(playersElement);
            rootElement.AppendChild(questionsElement);
			rootElement.AppendChild(miscElement);
			
			#region Players
			foreach(Player player in Player.All)
            {
                XmlElement playerElement = document.CreateElement("player");
                XmlAttribute nameAttribute = document.CreateAttribute("name");
                XmlAttribute pointsAttribute = document.CreateAttribute("points");
                XmlAttribute inGameAttribute = document.CreateAttribute("inGame");
                XmlAttribute iconAttribute = document.CreateAttribute("icon");

                nameAttribute.InnerText = player.Name;
                pointsAttribute.InnerText = player.Points.ToString();
                inGameAttribute.InnerText = player.inGame.ToString();
                if (player.PlayerIcon != null)
                {
                    DirectoryInfo rootdir = new FileInfo(filePath).Directory;
                    string icoPath = "\\ico_" + player.Id.ToString() + "_" + player.Name + ".bkbiIco";
                    player.PlayerIcon.Save(rootdir.FullName + icoPath);
                    iconAttribute.InnerText = "##bkbi:tempExtractPath" + icoPath;
                }
                playerElement.Attributes.Append(nameAttribute);
                playerElement.Attributes.Append(pointsAttribute);
                playerElement.Attributes.Append(inGameAttribute);
                playerElement.Attributes.Append(iconAttribute);

                playersElement.AppendChild(playerElement);
            }
            #endregion

            #region Questions
            XmlAttribute dictAttrib = document.CreateAttribute("dictionaryPath");
            dictAttrib.InnerText = DictionaryWord.DictionaryPath;
            questionsElement.Attributes.Append(dictAttrib);
            foreach(Questions question in Questions.All)
            {
                switch (question.Type)
                {
                    case Questions.TypeEnum.AutoEquation:
                        AutoEquationProcessor(question, document, ref questionsElement);
                        break;
                    case Questions.TypeEnum.DictionaryWord:
                        DictionaryWordProcessor(question, document, ref questionsElement);
                        break;
                    case Questions.TypeEnum.UserEquation:
                        UserEquationProcessor(question, document, ref questionsElement);
                        break;
                    case Questions.TypeEnum.UserWord:
                        UserWordProcessor(question, document, ref questionsElement);
                        break;
                }
            }
            #endregion

            document.AppendChild(declaration);
            document.AppendChild(rootElement);

            document.Save(filePath);
        }

        private static void QuestionProcessor(Questions question, XmlDocument doc, ref XmlElement questionElement)
        {
            if (questionElement == null) throw new ArgumentNullException("questionElemnt");
            XmlAttribute worthAttribute = doc.CreateAttribute("worth");
            XmlAttribute usedAttribute = doc.CreateAttribute("used");

            worthAttribute.InnerText = question.MaximumWorthInPoints.ToString();
            usedAttribute.InnerText = question.Used.ToString();

            questionElement.Attributes.Append(worthAttribute);
            questionElement.Attributes.Append(usedAttribute);
        }

        private static void AutoEquationProcessor(Questions autoEq, XmlDocument doc, ref XmlElement questionsElement)
        {
            if (autoEq.Type != Questions.TypeEnum.AutoEquation) throw new ArgumentException("Given question isn't an auto equation. Failed!", "autoEq");
            XmlElement autoEquationElement = doc.CreateElement("autoEquation");
            QuestionProcessor(autoEq, doc, ref autoEquationElement);
            questionsElement.AppendChild(autoEquationElement);
        }

        private static void DictionaryWordProcessor(Questions dictionaryWord, XmlDocument doc, ref XmlElement questionsElement)
        {
            if (dictionaryWord.Type != Questions.TypeEnum.DictionaryWord) throw new ArgumentException("Given question isn't a dictionaryWord. Failed!", "dictionaryWord");
            XmlElement dictionaryWordElement = doc.CreateElement("dictionaryWord");
            QuestionProcessor(dictionaryWord, doc, ref dictionaryWordElement);
            questionsElement.AppendChild(dictionaryWordElement);
        }

        private static void UserEquationProcessor(Questions question, XmlDocument doc, ref XmlElement questionsElement)
        {
            if (question.Type != Questions.TypeEnum.UserEquation) throw new ArgumentException("Given question isn't a dictionaryWord. Failed!", "userEquation");
            XmlElement userEquationElement = doc.CreateElement("userEquation");
            QuestionProcessor(question, doc, ref userEquationElement);

            UserEquation userEquation = question as UserEquation;

            XmlAttribute numberAttribute = doc.CreateAttribute("numbers");
            XmlAttribute sumAttribute = doc.CreateAttribute("sum");
            XmlAttribute solutionAttribute = doc.CreateAttribute("solution");

            List<string> numbersConvert = new List<string>();
            foreach(int i in userEquation.numbers)
            {
                numbersConvert.Add(i.ToString());
            }

            numberAttribute.InnerText = string.Join(",", numbersConvert.ToArray());

            sumAttribute.InnerText = userEquation.sum.ToString();

            solutionAttribute.InnerText = userEquation.solve;

            userEquationElement.Attributes.Append(numberAttribute);
            userEquationElement.Attributes.Append(sumAttribute);
            userEquationElement.Attributes.Append(solutionAttribute);

            questionsElement.AppendChild(userEquationElement);
        }

        private static void UserWordProcessor(Questions question, XmlDocument doc, ref XmlElement questionsElement)
        {
            if (question.Type != Questions.TypeEnum.UserWord) throw new ArgumentException("Given question isn't a user word. Failed!", "question");
            XmlElement userWordElement = doc.CreateElement("userWord");
            QuestionProcessor(question, doc, ref userWordElement);

            UserWord userWord = question as UserWord;
            XmlAttribute wordAttribute = doc.CreateAttribute("word");

            wordAttribute.InnerText = userWord.Word;
            userWordElement.Attributes.Append(wordAttribute);

            questionsElement.AppendChild(userWordElement);
        }
    }
}