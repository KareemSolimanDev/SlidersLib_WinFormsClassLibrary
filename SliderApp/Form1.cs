using SlidersLib;
namespace SliderApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            List<KeyValuePair<string, Image>> imagesData = [];
            imagesData.Add(new KeyValuePair<string, Image>("image 1", Properties.Resources.img1));
            imagesData.Add(new KeyValuePair<string, Image>("image 2", Properties.Resources.img2));
            imagesData.Add(new KeyValuePair<string, Image>("image 3", Properties.Resources.img3));


            // for infinite slider add true as 5th argument in CTOR
            // Slider sldr = new Slider(pictureBox1, label1, button1, button2,true);
            Slider sldr = new Slider(pictureBox1, label1, button1, button2);

            sldr.addImage(imagesData);

            button1.Click += sldr.prevBtn_Clicked;
            button2.Click += sldr.nextBtn_Clicked;

            sldr.render();


        }

    }
}
