﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PairTradingView.Csv;
using PairTradingView.Synthetics;

namespace PairTradingView.Tests.Logic.Synthetics
{
    [TestClass]
    public class SpreadSyntheticsTest
    {
        [TestMethod]
        public void CreateSynthetic()
        {
            var JPM = CsvFile.Read("csv-files/JPM.txt", 4, false);
            var GS = CsvFile.Read("csv-files/GS.txt", 4, false);

            var synth = new Synthetic(JPM, GS, new SyntheticName("JPM", "GS"), new SpreadDelta());

            Assert.AreEqual("GS/JPM", synth.Name.ToString());

            Assert.AreEqual(473, synth.DeltaValues.Length);

            Assert.AreEqual(-50, synth.GetValue(100, 50));

            Assert.AreEqual("Spread", synth.Delta.Name);



            synth = new Synthetic(JPM, GS, new SyntheticName("JPM", "GS"), new RatioDelta());

            Assert.AreEqual("GS/JPM", synth.Name.ToString());

            Assert.AreEqual(473, synth.DeltaValues.Length);

            Assert.AreEqual(0.0348, (double)synth.GetValue(345.56M, 12.034M), 0.001);

            Assert.AreEqual("Ratio", synth.Delta.Name);
        }
    }
}