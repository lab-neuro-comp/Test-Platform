using System;
using System.Collections.Generic;
using System.IO;
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
                                     this.medicationEspecification + "\n"+
                                     this.relaxantEspecification + "\n" +
                                     this.sleepEspecification + "\n" +
                                     this.alcoholEspecification + "\n" +
                                     this.drugsEspecification + "\n" +
                                     this.energizersEspecification;
            
            return participantData;
        }

        public bool saveParticipantFile()
        {
            StreamWriter writer = new StreamWriter(Global.testFilesPath + Global.partcipantDataPath + name + registrationID + ".data");
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
    }
}
