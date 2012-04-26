using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.Finders;
using White.Core.UIItems.WindowItems;

namespace PickAWinnerTDD.UI.Tests.AutomatedUI {

    [TestClass]
    public class MainWindow_AdminMenuOptionClicked_Tests {

        #region << Private Fields >>

        private static Application _app;
        private static Window _window;

        #endregion

        #region << Setup/Tear Down >>

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext) {
            _app = Application.Launch(@"D:\Dev\PickAWinnerTDD\PickAWinnerTDD.UI\bin\Debug\PickAWinnerTDD.UI.exe");
            _window = _app.GetWindow("Pick A Winner");
            _window.Get<Button>(SearchCriteria.ByText("Admin")).Click();
        }

        [ClassCleanup]
        public static void ClassCleanup() {
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
        public void LoadAttendees_Button_ShouldBe_Displayed() {
            //Act
            var button = _window.Get<Button>("LoadAttendees");
            //Assert
            button.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void ResetHasWon_Button_ShouldBe_Displayed() {
            //Act
            var button = _window.Get<Button>("ResetHasWon");
            //Assert
            button.Visible.ShouldBeTrue("Expected True");
        }

        [TestMethod]
        public void SponsorName_Label_ShouldNotBe_Displayed() {
            //Act
            var label = _window.Get<Label>("SponsorName");
            //Assert
            label.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void SwagImage_Image_ShouldNotBe_Displayed() {
            //Act
            var image = _window.Get<Image>("SwagImage");
            //Assert
            image.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void SwagName_Label_ShouldNotBe_Displayed() {
            //Act
            var label = _window.Get<Label>("SwagName");
            //Assert
            label.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void WinnersName_Label_ShouldNotBe_Displayed() {
            //Act
            var label = _window.Get<Label>("WinnersName");
            //Assert
            label.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void PickAWinner_Button_ShouldNotBe_Displayed() {
            //Act
            var button = _window.Get<Button>("PickAWinner");
            //Assert
            button.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void PrevSwagItem_Button_ShouldNotBe_Displayed() {
            //Act
            var button = _window.Get<Button>("PrevSwagItem");
            //Assert
            button.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void NextSwagItem_Button_ShouldNotBe_Displayed() {
            //Act
            var button = _window.Get<Button>("NextSwagItem");
            //Assert
            button.Visible.ShouldBeFalse("Expected False");
        }


        [TestMethod]
        public void GrandPrizeImage_Image_ShouldNotBe_Displayed() {
            //Act
            var image = _window.Get<Image>("GrandPrizeImage");
            //Assert
            image.Visible.ShouldBeFalse("Expected False");
        }

        [TestMethod]
        public void BigWinnersName_Label_ShouldNotBe_Displayed()
        {
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
        #endregion

    }
}