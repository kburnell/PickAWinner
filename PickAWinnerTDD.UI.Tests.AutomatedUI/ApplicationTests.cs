using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using White.Core;
using White.Core.UIItems.WindowItems;

namespace PickAWinnerTDD.UI.Tests.AutomatedUI {

    [TestClass]
    public class ApplicationTests {

        #region Private Fields

        private Application _app;

        #endregion

        #region Setup & Tear Down

        [TestInitialize]
        public void MyTestInitialize() {
            _app = Application.Launch(@"D:\Dev\PickAWinnerTDD\PickAWinnerTDD.UI\bin\Debug\PickAWinnerTDD.UI.exe");
        }

        [TestCleanup]
        public void MyTestCleanup() {
            _app.Kill();
        }

        #endregion

        [TestMethod]
        public void OnApplicationStart_TheMainWindow_ShouldBeDisplayed() {
            //Act
            Window window = _app.GetWindow("Pick A Winner");
            //Assert
            window.ShouldNotBeNull();
        }

    }
}