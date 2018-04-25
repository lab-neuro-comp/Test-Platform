using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestPlatform.Views;

namespace TestPlatform.Models.General
{
    class Participant
    {
        public Participant(string name, int registrationID, int sex, string livingLocation, int degreeOfSchooling, int age,
            DateTime birthDate, DateTime lastPeriodDate, int reasonForNotMenstruating,
            bool wearGlass, bool usesMedication, bool consumedEnergizers, bool consumedDrugs,
            bool usedRelaxant, bool consumedAlcohol, bool goodLastNightOfSleep, string glassesEspecification,
            string medicationEspecification, string relaxantEspecification, string sleepEspecification,
            string alcoholEspecification, string drugsEspecification, string energizersEspecification, List<string> observations)
        {
            this.name = name;
            this.registrationID = registrationID;
            this.sex = sex;
            this.livingLocation = livingLocation;
            this.degreeOfSchooling = degreeOfSchooling;
            this.age = age;
            this.birthDate = birthDate;
            this.lastPeriodDate = lastPeriodDate;
            this.reasonForNotMenstruating = reasonForNotMenstruating;
            this.wearGlasses = wearGlass;
            this.usesMedication = usesMedication;
            this.consumedAlcohol = consumedAlcohol;
            this.consumedDrugs = consumedDrugs;
            this.consumedEnergizers = consumedEnergizers;
            this.goodLastNightOfSleep = goodLastNightOfSleep;
            this.usedRelaxant = usedRelaxant;
            this.glassesEspecification = glassesEspecification;
            this.medicationEspecification = medicationEspecification;
            this.relaxantEspecification = relaxantEspecification;
            this.sleepEspecification = sleepEspecification;
            this.alcoholEspecification = alcoholEspecification;
            this.drugsEspecification = drugsEspecification;
            this.energizersEspecification = energizersEspecification;
            this.observations = observations;
    }
        private int registrationID;
        private string name;

        /// <summary> 1 female 2 male </summary>
        private int sex;
        /// <summary> City or state of residence </summary>
        private string livingLocation;

        /// <summary>  
        /// 1. Elementary school
        /// 2. High school
        /// 3.Incomplete higher education
        /// 4. Complete higher education
        /// 5. Post graduate
        /// </summary>
        private int degreeOfSchooling;

        private int age;
        private DateTime birthDate;
        private DateTime lastPeriodDate;

        /// <summary> 0 do not apply 1 Usage of continuos contraception and 3 menopause </summary>
        private int reasonForNotMenstruating;

        private bool wearGlasses;

        private bool usesMedication;

        private bool goodLastNightOfSleep;

        /// <summary> True if participant consumed alcohol in past 24 hours </summary>
        private bool consumedAlcohol;

        /// <summary> True if participant used any relaxant in past 24 hours </summary>
        private bool usedRelaxant;

        /// <summary> True if participant consumed any illicit drugs in past 24 hours </summary>
        private bool consumedDrugs;

        /// <summary> True if participant consumed coffe, soda, chocolate or any energizer drink in the last 2 hours prior to test </summary>
        private bool consumedEnergizers;

        private string glassesEspecification;
        private string medicationEspecification;
        private string relaxantEspecification;
        private string sleepEspecification;
        private string alcoholEspecification;
        private string drugsEspecification;
        private string energizersEspecification;

        /// <summary> Any complementar comment goes here </summary>
        private List<string> observations = new List<string>();

        private string Data()
        {
            string participantData = this.registrationID + " " +
                                     this.name + " " +
                                     this.age + " " +
                                     this.sex + " " +
                                     this.livingLocation + " " +
                                     this.degreeOfSchooling + " " +
                                     this.birthDate.Date + " " +
                                     this.lastPeriodDate.Date + " " +
                                     this.reasonForNotMenstruating + " " +
                                     this.wearGlasses + " " +
                                     this.usesMedication + " " +
                                     this.goodLastNightOfSleep + " " +
                                     this.consumedAlcohol + " " +
                                     this.usedRelaxant + " " +
                                     this.consumedDrugs + " " +
                                     this.consumedEnergizers + "\n" +
                                     this.glassesEspecification + "\n" +
                                     this.medicationEspecification + "\n" +
                                     this.relaxantEspecification + "\n" +
                                     this.sleepEspecification + "\n" +
                                     this.alcoholEspecification + "\n" +
                                     this.drugsEspecification + "\n" +
                                     this.energizersEspecification + "\n";
            
            return participantData;
        }

        public string getParticipantPath()
        {
            return Global.testFilesPath + Global.partcipantDataPath + name + "-" + registrationID + ".data";
        }

        public string getParticipantPath(string filename)
        {
            return Global.testFilesPath + Global.partcipantDataPath + filename + ".data";
        }

        public bool saveParticipantFile()
        {
            StreamWriter writer = new StreamWriter(getParticipantPath());
            writer.Write(Data());
            if (observations != null)
            {
                for (int i = 0; i < observations.Count; i++)
                {
                    writer.WriteLine(observations[i]);
                }
            }
            writer.Close();
            return true;
        }
 

        public bool readParticipantFile(string fileName)
        {
            if(File.Exists(getParticipantPath(fileName)))
            {
                StreamReader tr;
                string line;
                string[] linesInstruction;
                List<string> config = new List<string>();

                tr = new StreamReader(getParticipantPath(fileName), Encoding.Default, true);
                line = tr.ReadLine();
                line = Program.encodeLatinText(line);
                config = line.Split().ToList();
                tr.Close();

                this.registrationID = int.Parse(config[0]);
                this.name = config[1];
                this.age = int.Parse(config[2]);
                this.sex = int.Parse(config[3]);
                this.livingLocation = config[4];
                this.degreeOfSchooling = int.Parse(config[5]);
                this.birthDate.AddYears(DateTime.Parse(config[6]).Year);
                this.birthDate.AddMonths(DateTime.Parse(config[6]).Month);
                this.birthDate.AddDays(DateTime.Parse(config[6]).Day);
                this.lastPeriodDate.AddYears(DateTime.Parse(config[7]).Year);
                this.lastPeriodDate.AddMonths(DateTime.Parse(config[7]).Month);
                this.lastPeriodDate.AddDays(DateTime.Parse(config[7]).Day);
                this.reasonForNotMenstruating = int.Parse(config[8]);
                this.wearGlasses = bool.Parse(config[9]);
                this.usesMedication = bool.Parse(config[10]);
                this.goodLastNightOfSleep = bool.Parse(config[11]);
                this.consumedAlcohol = bool.Parse(config[12]);
                this.usedRelaxant = bool.Parse(config[13]);
                this.consumedDrugs = bool.Parse(config[14]);
                this.consumedEnergizers = bool.Parse(config[15]);
                this.glassesEspecification = config[16];
                this.medicationEspecification = config[17];
                this.relaxantEspecification = config[18];
                this.sleepEspecification = config[19];
                this.alcoholEspecification = config[20];
                this.drugsEspecification = config[21];
                this.energizersEspecification = config[22];
                linesInstruction = File.ReadAllLines(getParticipantPath(fileName));
                if (linesInstruction.Length > 1) // read instructions if any
                {
                    for (int i = 1; i < linesInstruction.Length; i++)
                    {
                        this.observations.Add(linesInstruction[i]);
                    }
                }
                else
                {
                    this.observations = null;
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            return false;
        }
    }
}
