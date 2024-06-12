namespace SlidersLib
{
    public class Slider
    {
        private bool _isInfinite;
        private byte _currentImageIndex = 0;
        // using key as a title of image and value as an image.
        private List<KeyValuePair<string, Image>> _imagesData = [];

        private PictureBox _viewer;
        private Label _title;

        private Button _prevBtn;
        private Button _nextBtn;

        private void _updateViewer()
        {
            _title.Text = _imagesData[_currentImageIndex].Key;

            _viewer.Image = _imagesData[_currentImageIndex].Value;

        }

        private void nextBtn_Click()
        {
            if (_isInfinite)
            {
                if (_currentImageIndex == _imagesData.Count - 1)
                    _currentImageIndex = 0;
                else
                    _currentImageIndex++;

            }
            else
            {
                _prevBtn.Enabled = true;
                _currentImageIndex++;

                if (_currentImageIndex == _imagesData.Count - 1)
                    _nextBtn.Enabled = false;
            }

            _updateViewer();
        }

        private void prevBtn_Click()
        {
            if (_isInfinite)
            {
                if (_currentImageIndex == 0)
                    _currentImageIndex = (byte)(_imagesData.Count - 1);
                else
                    _currentImageIndex--;
            }
            else
            {
                _nextBtn.Enabled = true;
                _currentImageIndex--;

                if (_currentImageIndex == 0)
                    _prevBtn.Enabled = false;
            }

            _updateViewer();
        }

        public Slider(PictureBox viewer, Label title, Button prevBtn, Button nextBtn, bool isInfinite = false)
        {
            _viewer = viewer;
            _title = title;
            _prevBtn = prevBtn;
            _nextBtn = nextBtn;
            _isInfinite = isInfinite;
        }

        public void addImage(string title, Image image)
        {
            KeyValuePair<string, Image> imageData = new(title, image);
            _imagesData.Add(imageData);
        }
        public void addImage(KeyValuePair<string, Image> imageData)
        {
            _imagesData.Add(imageData);
        }
        public void addImage(List<KeyValuePair<string, Image>> imagesData)
        {
            _imagesData = imagesData;
        }

        public void nextBtn_Clicked(object? sender, EventArgs e)
        {
            nextBtn_Click();
        }

        public void prevBtn_Clicked(object? sender, EventArgs e)
        {
            prevBtn_Click();
        }

        public void render()
        {
            _updateViewer();
        }
    }
}
