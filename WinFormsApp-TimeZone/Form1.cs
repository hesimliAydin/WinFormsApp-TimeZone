using System.Resources;
using WinFormsApp_TimeZone.Properties;

namespace WinFormsApp_TimeZone;

public partial class Form1 : Form
{
	enum Choices { Baku = 4, London = 1 }
	public DateTime CurrentTimeZone;

	public Form1()
	{
		InitializeComponent();
		TimerExample();
		ChangeDesign(Choices.Baku);
	}

	void ChangeDesign(Choices choice)
	{
		CurrentTimeZone = DateTime.UtcNow.AddHours((int)choice);

		switch (choice)
		{
			case Choices.Baku:
				BackgroundImage = Resources._118f2684022887_5d4ea01c02748;
				break;
			case Choices.London:
				BackgroundImage = Resources.London;
				break;
			default:
				break;
		}

		BackgroundImageLayout = ImageLayout.Zoom;
	}

	private void TimerExample()
	{
		System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

		timer.Interval = 1000;
		timer.Tick += Timer_Tick;
		timer.Start();
	}

	private void Timer_Tick(object? sender, EventArgs e)
	{
		CurrentTimeZone = CurrentTimeZone.AddSeconds(1);
		lbl_Time.Text = CurrentTimeZone.ToLongTimeString();
	}

	private void btn_London_Click(object sender, EventArgs e) => ChangeDesign(Choices.London);

	private void btn_Baku_Click(object sender, EventArgs e) => ChangeDesign(Choices.Baku);
}