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

        public Participant(string fileName)
        {
            readParticipantFile(fileName);
        }

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
            this.DegreeOfSchooling = degreeOfSchooling;
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




        private string Data()
        {
            string participantData = this.registrationID + " " +
                                     this.name + " " +
                                     this.age + " " +
                                     this.sex + " " +
                                     this.livingLocation + " " +
                                     this.DegreeOfSchooling + " " +
                                     this.birthDate.Date.ToShortDateString() + " " +
                                     this.lastPeriodDate.Date.ToShortDateString() + " " +
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
            return Global.testFilesPath + Global.partcipantDataPath + registrationID + "-" + name + ".data";
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


        private void readParticipantFile(string fileName)
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

                this.registrationID = int.Parse(config[0]);
                this.name = config[1];
                this.age = int.Parse(config[2]);
                this.sex = int.Parse(config[3]);
                this.livingLocation = config[4];
                this.DegreeOfSchooling = int.Parse(config[5]);
                this.birthDate = DateTime.Parse(config[6]);
                this.lastPeriodDate = DateTime.Parse(config[7]);
                this.reasonForNotMenstruating = int.Parse(config[8]);
                this.wearGlasses = bool.Parse(config[9]);
                this.usesMedication = bool.Parse(config[10]);
                this.goodLastNightOfSleep = bool.Parse(config[11]);
                this.consumedAlcohol = bool.Parse(config[12]);
                this.usedRelaxant = bool.Parse(config[13]);
                this.consumedDrugs = bool.Parse(config[14]);
                this.consumedEnergizers = bool.Parse(config[15]);

                this.glassesEspecification = Program.encodeLatinText(tr.ReadLine());
                this.medicationEspecification = Program.encodeLatinText(tr.ReadLine());
                this.relaxantEspecification = Program.encodeLatinText(tr.ReadLine());
                this.sleepEspecification = Program.encodeLatinText(tr.ReadLine());
                this.alcoholEspecification = Program.encodeLatinText(tr.ReadLine());
                this.drugsEspecification = Program.encodeLatinText(tr.ReadLine());
                this.energizersEspecification = Program.encodeLatinText(tr.ReadLine());
                tr.Close();
                linesInstruction = File.ReadAllLines(getParticipantPath(fileName));
                if (linesInstruction.Length > 8) // read instructions if any
                {
                    for (int i = 8; i < linesInstruction.Length; i++)
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
        }



        /// <summary>
        ///  getters and setters below
        /// </summary>
       
        public int DegreeOfSchooling { get => degreeOfSchooling; set => degreeOfSchooling = value; }

        public int Age { get => age; set => age = value; }

        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public DateTime LastPeriodDate { get => lastPeriodDate; set => lastPeriodDate = value; }

        public int ReasonForNotMenstruating { get => reasonForNotMenstruating; set => reasonForNotMenstruating = value; }

        public bool WearGlasses { get => wearGlasses; set => wearGlasses = value; }

        public bool UsesMedication { get => usesMedication; set => usesMedication = value; }

        public bool GoodLastNightOfSleep { get => goodLastNightOfSleep; set => goodLastNightOfSleep = value; }

        public bool ConsumedAlcohol { get => consumedAlcohol; set => consumedAlcohol = value; }

        public bool UsedRelaxant { get => usedRelaxant; set => usedRelaxant = value; }

        public bool ConsumedDrugs { get => consumedDrugs; set => consumedDrugs = value; }

        public bool ConsumedEnergizers { get => consumedEnergizers; set => consumedEnergizers = value; }

        public string GlassesEspecification { get => glassesEspecification; set => glassesEspecification = value; }

        public string MedicationEspecification { get => medicationEspecification; set => medicationEspecification = value; }

        public string RelaxantEspecification { get => relaxantEspecification; set => relaxantEspecification = value; }

        public string SleepEspecification { get => sleepEspecification; set => sleepEspecification = value; }

        public string AlcoholEspecification { get => alcoholEspecification; set => alcoholEspecification = value; }

        public string DrugsEspecification { get => drugsEspecification; set => drugsEspecification = value; }

        public string EnergizersEspecification { get => energizersEspecification; set => energizersEspecification = value; }

        public List<string> Observations { get => observations; set => observations = value; }

        public string LivingLocation { get => livingLocation; set => livingLocation = value; }

        public int Sex { get => sex; set => sex = value; }

        public string Name { get => name; set => name = value; }

        public int RegistrationID { get => registrationID; set => registrationID = value; }
    }
}
