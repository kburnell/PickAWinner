using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Service;

namespace PickAWinnerTDD.UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        #region Private Fields

        private readonly int _totalCount;
        private int _currentSponsorIndex;
        private int _currentSwagIndex;
        private IList<SponsorDTO> _sponsors;
        private IList<SwagDTO> _swags;
        private IList<WinnerDTO> _winners = new List<WinnerDTO>();
        private WinnerDTO _theWinner;

        #endregion

        #region Public Methods

        public MainWindow() {
            InitializeComponent();
            _totalCount = new AttendeeService().GetAll().Count;
        }

        #endregion

        #region Private Methods

        #region Menu Events

        private void Admin_Click(object sender, RoutedEventArgs e) {
            SetPanelVisibility(true, false, false);
        }

        private void PickWinner_Click(object sender, RoutedEventArgs e) {
            SetPanelVisibility(false, true, false);
            _winners = new List<WinnerDTO>();
            _sponsors = new List<SponsorDTO>();
            _swags = new List<SwagDTO>();
            _currentSwagIndex = 0;
            _currentSponsorIndex = 0;
            _sponsors = (from x in new SponsorService().GetAllThatProvidedSwag() orderby x.Position where x.ProvidedSwag select x).ToList();
            LoadSponsor(false);
            PickAWinner.IsEnabled = true;
        }

        private void PickBigWinner_Click(object sender, RoutedEventArgs e) {
            SetPanelVisibility(false, false, true);
        }

        private void SetPanelVisibility(bool showAdmin, bool showPickAWinner, bool showPickTheBigWinner) {
            AdminPanel.Visibility = showAdmin ? Visibility.Visible : Visibility.Collapsed;
            Status.Text = string.Empty;
            Error.Text = string.Empty;
            PickAWinnerPanel.Visibility = showPickAWinner ? Visibility.Visible : Visibility.Collapsed;
            WinnersName.Text = string.Empty;
            PickTheBigWinnerPanel.Visibility = showPickTheBigWinner ? Visibility.Visible : Visibility.Collapsed;
            BigWinnersName.Text = string.Empty;
        }

        #endregion

        #region Admin

        private void ResetHasWon_Click(object sender, RoutedEventArgs e) {
            new AttendeeService().ResetAllHasWon();
            new WinnerService().DeleteAll();
            Status.Text = string.Format("Successfully reset HasWon and Winners");
        }

        private void LoadAttendees_Click(object sender, RoutedEventArgs e) {
            try {
                XDocument xmlDoc = XDocument.Load("D:\\Dev\\PickAWinner\\Attendees.xml");
                IList<AttendeeDTO> attendees = (from x in xmlDoc.Descendants("Attendee") select new AttendeeDTO {FirstName = x.Element("FirstName").Value, LastName = x.Element("LastName").Value, HasWon = false, IsEligible = true}).ToList();
                if (attendees.Count == 0) {
                    Status.Text = "Error";
                    Error.Text = "No attendees where loaded!  Has Attendees.xml been populated?";
                }
                else {
                    AttendeeService service = new AttendeeService();
                    service.DeleteAll();
                    service.InsertAll(attendees);
                    Status.Text = string.Format("Successfully loaded {0} attendees.", attendees.Count);
                }
            }
            catch (Exception ex) {
                Status.Text = "Error";
                Error.Text = "Error Loading Attendees: " + ex.Message;
            }
        }

        #endregion

        #region Pick A Winner

        private void PickAWinner_Click(object sender, RoutedEventArgs e) {
            bool foundAWinner = false;
            AttendeeDTO winner = new AttendeeDTO();
            IList<AttendeeDTO> attendees = new AttendeeService().GetAll();
            while (!foundAWinner) {
                var rand = new Random();
                int next = rand.Next(0, _totalCount - 1);
                winner = (from x in attendees select x).ToList().Skip(next).Take(1).FirstOrDefault();
                foundAWinner = (!winner.HasWon && winner.IsEligible);
            }
            winner.HasWon = true;
            WinnersName.Text = string.Format("{0} {1}", winner.FirstName, winner.LastName);
            _theWinner = new WinnerDTO { AttendeeID = winner.AttendeeID, Name = WinnersName.Text, SponsorID = _sponsors[_currentSponsorIndex].SponsorID, SwagID = _swags[_currentSwagIndex].SwagID };
            new AttendeeService().SetHasWon(_theWinner.AttendeeID);
            //PickAWinner.IsEnabled = false;
        }

        private void LoadSponsor(bool goingBack) {
            if (_currentSponsorIndex < _sponsors.Count) {
                LoadSwag(_sponsors[_currentSponsorIndex].SponsorID);
                SponsorName.Text = _sponsors[_currentSponsorIndex].Name;
                if (goingBack)
                    _currentSwagIndex = _swags.Count - 1;
                SetSwagDetails(_swags[_currentSwagIndex]);
            }
            else {
                NextSwagItem.IsEnabled = false;
                NextSwagItem.Content = "All Done!";
                SetPanelVisibility(false, false, true);
            }
        }

        private void LoadSwag(long sponsorID) {
            _swags = (from x in new SwagService().GetAllBySponsor(sponsorID) orderby x.Position select x).ToList();
        }

        private void SetSwagDetails(SwagDTO swag) {
            SwagImage.Source = CreateBitmapImage(swag.ImageLocation);
            SwagName.Text = swag.Name;
        }

        private static BitmapImage CreateBitmapImage(string imagePath) {
            var image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(@imagePath);
            image.EndInit();
            return image;
        }

        private void NextSwagItem_Click(object sender, RoutedEventArgs e) {
            if (_currentSwagIndex != _swags.Count - 1) {
                _currentSwagIndex += 1;
                SetSwagDetails(_swags[_currentSwagIndex]);
            }
            else {
                _currentSwagIndex = 0;
                _currentSponsorIndex += 1;
                LoadSponsor(false);
            }
            SetWinnersNameInfo();
        }

        private void PrevSwagItem_Click(object sender, RoutedEventArgs e) {
            if (_currentSwagIndex != 0) {
                _currentSwagIndex -= 1;
                SetSwagDetails(_swags[_currentSwagIndex]);
                SetWinnersNameInfo();
            }
            else {
                if (_currentSponsorIndex != 0) {
                    _currentSwagIndex = 0;
                    _currentSponsorIndex -= 1;
                    LoadSponsor(true);
                    SetWinnersNameInfo();
                }
            }
        }

        private void SaveWinner_Click(object sender, RoutedEventArgs e) {
            if (_theWinner != null) {
                new WinnerService().Insert(_theWinner);
                _winners.Add(_theWinner);
                _theWinner = null;
            }
        }

        private void SetWinnersNameInfo() {
            WinnerDTO winner = (from x in _winners where x.SponsorID == _sponsors[_currentSponsorIndex].SponsorID && x.SwagID == _swags[_currentSwagIndex].SwagID select x).FirstOrDefault();
            if (winner != null) {
                WinnersName.Text = (from x in _winners where x.SponsorID == _sponsors[_currentSponsorIndex].SponsorID && x.SwagID == _swags[_currentSwagIndex].SwagID select x.Name).FirstOrDefault();
                PickAWinner.IsEnabled = false;
            }
            else {
                WinnersName.Text = string.Empty;
                PickAWinner.IsEnabled = true;
            }
        }

        #endregion

        #region Pick The Big Winner

        private void PickTheBigWinner_Click(object sender, RoutedEventArgs e) {
            bool foundAWinner = false;
            var winner = new AttendeeDTO();
            while (!foundAWinner) {
                var rand = new Random();
                int next = rand.Next(0, _totalCount - 1);
                next = rand.Next(0, _totalCount - 1);
                winner = (from x in new AttendeeService().GetAllEligible() select x).ToList().Skip(next).Take(1).FirstOrDefault();
                foundAWinner = (winner.IsEligible);
            }
            winner.HasWon = true;
            BigWinnersName.Text = string.Format("{0} {1}", winner.FirstName, winner.LastName);
            new AttendeeService().SetHasWon(winner.AttendeeID);
        }

        #endregion

        #endregion
    }
}