using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace PickAWinnerTDD.UI.Tests.AutomatedUI {

    [TestClass]
    public class MainWindow_PickAWinnerMenuOptionClicked_Tests {

        #region << Private Fields >>

        private static Application _app;
        private static Window _window;

        #endregion

        #region << Setup/Tear Down >>

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext) {
            _app = Application.Launch(@"D:\Dev\PickAWinnerTDD\PickAWinnerTDD.UI\bin\Debug\PickAWinnerTDD.UI.exe");
            _window = _app.GetWindow("Pick A Winner");
            _window.Get<Button>(SearchCriteria.ByText("Pick A Winner")).Click();
        }

        [ClassCleanup]
        public static void ClassCleanup() {
            _window.Get<Button>(SearchCriteria.ByText("Admin")).Click();
            _window.Get<Button>("ResetHasWon").Click();
            _app.Kill();
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void Admin_MenuOption_ShouldBe_Displayed() {
            //Act
            var button = _window.Get<Button>(SearchCriteria.ByText("Admin"));
            //Assert
            button.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void PickAWinner_MenuOption_ShouldBe_Displayed() {
            //Act
            var button = _window.Get<Button>(SearchCriteria.ByText("Pick A Winner"));
            //Assert
            button.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void PickTheBigWinner_MenuOption_ShouldBe_Displayed() {
            //Act
            var button = _window.Get<Button>(SearchCriteria.ByText("Pick The BIG Winner"));
            //Assert
            button.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void LoadAttendees_Button_ShouldNotBe_Displayed() {
            //Act
            var button = _window.Get<Button>("LoadAttendees");
            //Assert
            button.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void ResetHasWon_Button_ShouldNotBe_Displayed() {
            //Act
            var button = _window.Get<Button>("ResetHasWon");
            //Assert
            button.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void SponsorName_Label_ShouldBe_Displayed() {
            //Act
            var label = _window.Get<Label>("SponsorName");
            //Assert
            label.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void SwagImage_Image_ShouldBe_Displayed() {
            //Act
            var image = _window.Get<Image>("SwagImage");
            //Assert
            image.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void SwagName_Label_ShouldBe_Displayed() {
            //Act
            var label = _window.Get<Label>("SwagName");
            //Assert
            label.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void WinnersName_Label_ShouldBe_Displayed() {
            //Act
            var label = _window.Get<Label>("WinnersName");
            //Assert
            label.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void PickAWinner_Button_ShouldBe_Displayed() {
            //Act
            var button = _window.Get<Button>("PickAWinner");
            //Assert
            button.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void PrevSwagItem_Button_ShouldBe_Displayed() {
            //Act
            var button = _window.Get<Button>("PrevSwagItem");
            //Assert
            button.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void NextSwagItem_Button_ShouldBe_Displayed() {
            //Act
            var button = _window.Get<Button>("NextSwagItem");
            //Assert
            button.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void GrandPrizeImage_Image_ShouldNotBe_Displayed() {
            //Act
            var image = _window.Get<Image>("GrandPrizeImage");
            //Assert
            image.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void BigWinnersName_Label_ShouldNotBe_Displayed() {
            //Act
            var label = _window.Get<Label>("BigWinnersName");
            //Assert
            label.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void PickTheBigWinner_Button_ShouldNotBe_Displayed() {
            //Act
            var button = _window.Get<Button>("PickTheBigWinner");
            //Assert
            button.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void WhenClickingThe_NextSwagItem_Button_The_SwagName_ShouldChange() {
            //Arrange
            string swagName = _window.Get<Label>("SwagName").Text;
            //Act
            _window.Get<Button>("NextSwagItem").Click();
            //Assert
            _window.Get<Label>("SwagName").Text.ShouldNotEqual(swagName);
        }

        [TestMethod]
        public void WhenClickingThe_PickAWinner_Button_The_WinnersName_ShouldBeSet()
        {
            using (new TransactionScope()) {
                //Arrange
                string winnersName = _window.Get<Label>("WinnersName").Text;
                //Act
                _window.Get<Button>("PickAWinner").Click();
                //Assert
                _window.Get<Label>("WinnersName").Text.ShouldNotEqual(winnersName);
            }
        }

        #endregion
    }
}