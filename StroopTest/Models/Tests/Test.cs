using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TestPlatform.Models.General;

namespace TestPlatform.Models.Tests
{
    public abstract class Test
    {
        protected Char mark;
        protected static String headerOutputFileText;
        protected DateTime initialDate;           // test execution date
        protected String participantName;
        protected ResourceManager LocRM = new ResourceManager("TestPlatform.Resources.Localizations.LocalizedResources", typeof(FormMain).Assembly);
        protected CultureInfo currentCulture = CultureInfo.CurrentUICulture;

        // public abstract void WriteLineOutputResult();

        public string[] participant()
        {
            try
            {
                Participant participant = new Participant(participantName);
                return new string[] { participant.RegistrationID.ToString(), participant.Name };
            }
            catch(FileNotFoundException)
            {
                return new string[] { "-", ParticipantName };
            }            
        }

        public DateTime InitialDate
        {
            get
            {
                return initialDate;
            }

            set
            {
                initialDate = value;
            }
        }

        public char Mark
        {
            get
            {
                return mark;
            }

            set
            {
                mark = value;
            }
        }

        public string ParticipantName
        {
            get { return participantName; }
            set
            {
                // user name can have only alphanumeric elements, without spaces
                if (!Validations.isEmpty(value))
                {
                    participantName = value;
                }
                else
                {
                    throw new ArgumentException(LocRM.GetString("participantNameLengthError", currentCulture));
                }
            }
        }
    }
}
