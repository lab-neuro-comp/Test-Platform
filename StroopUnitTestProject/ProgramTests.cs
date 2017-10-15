using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestPlatform.Models;

namespace StroopUnitTestProject
{
    [TestClass]
    public class ProgramTests
    {

        // Testing method to set program name with valid input
        [TestMethod]
        public void ValidProgramName()
        {
            string expected = "ProgramName";
            Program newProgram = new Program();
            newProgram.ProgramName = expected;
            Assert.AreEqual(expected, newProgram.ProgramName);
        }

        // Testing method to set program name with invalid input
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Nome do programa deve ser composto apenas de caracteres alphanumericos " +
                                                "e sem espaços;\nExemplo: 'MeuPrograma'")]
        public void InvalidProgramName()
        {
            Program newProgram = new Program();
            newProgram.ProgramName = "Nome inválido";
        }

        // Testing method to set program name with null input
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Nome do programa deve ser composto apenas de caracteres alphanumericos " +
                                                "e sem espaços;\nExemplo: 'MeuPrograma'")]
        public void InvalidNullProgramName()
        {
            Program newProgram = new Program();
            newProgram.ProgramName = null;
        }

        // Testing method to set program number of expositions with valid input
        [TestMethod]
        public void ValidNumExpositions()
        {
            Random random = new Random();
            int expected = random.Next();
            Program newProgram = new Program();
            newProgram.NumExpositions = expected;
            Assert.AreEqual(expected, newProgram.NumExpositions);
        }

        // Testing method to set program exposition time with valid input
        [TestMethod]
        public void ValidExpositionTime()
        {
            Random random = new Random();
            int expected = random.Next(1,10000);
            Program newProgram = new Program();
            newProgram.ExpositionTime = expected;
            Assert.AreEqual(expected, newProgram.ExpositionTime);
        }

        // Testing method to set program numbers of expositions with invalid negative input
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nTempo de exposição deve ser maior que zero e menor que 10.000 (em milissegundos)")]
        public void InvalidNegativeExpositionTime()
        {
            Random random = new Random();
            int expected = -random.Next();
            Program newProgram = new Program();
            newProgram.ExpositionTime = expected;
        }

        // Testing method to set program numbers of expositions with invalid negative input
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nTempo de exposição deve ser maior que zero e menor que 10.000 (em milissegundos)")]
        public void InvalidGreatExpositionTime()
        {
            Random random = new Random();
            int expected = random.Next() + 10000;
            Program newProgram = new Program();
            newProgram.ExpositionTime = expected;
        }

        // Testing method to set program instructions
        [TestMethod]
        public void SetAndGetValidInstructions()
        {
            Program newProgram = new Program();
            List<string> expected = new List<string>();
            expected.Add("These are some instructions");
            newProgram.InstructionText = expected;
            Assert.AreEqual(expected, newProgram.InstructionText);
        }

        // Testing method to set program numbers of expositions with invalid negative input
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nTempo de exposição deve ser maior que zero (em milissegundos)")]
        public void InvalidNegativeNumExpositions()
        {
            Random random = new Random();
            int expected = - random.Next();
            Program newProgram = new Program();
            newProgram.NumExpositions = expected;
        }

        // Testing method to set program numbers of expositions with invalid zero input
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nTempo de exposição deve ser maior que zero (em milissegundos)")]
        public void InvalidZeroNumExpositions()
        {
            Random random = new Random();
            int expected = 0;
            Program newProgram = new Program();
            newProgram.NumExpositions = expected;
        }

        // Testing method to set program interval time with valid input
        [TestMethod]
        public void ValidIntervalTime()
        {
            Random random = new Random();
            int expected = random.Next();
            Program newProgram = new Program();
            newProgram.IntervalTime = expected;
            Assert.AreEqual(expected, newProgram.IntervalTime);
        }

        // Testing method to set program numbers of expositions with invalid negative input
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nTempo de intervalo deve ser maior que zero (em milissegundos)")]
        public void InvalidNegativeIntervalTime()
        {
            Random random = new Random();
            int expected = -random.Next();
            Program newProgram = new Program();
            newProgram.IntervalTime = expected;
        }

        // Testing method to set program numbers of expositions with invalid zero input
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "\nTempo de intervalo deve ser maior que zero (em milissegundos)")]
        public void InvalidZeroIntervalTime()
        {
            Random random = new Random();
            int expected = 0;
            Program newProgram = new Program();
            newProgram.IntervalTime = expected;
        }
    }
}
